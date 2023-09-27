using AutoMapper;
using LexiconApi.Data.DBContext;
using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LexiconApi.Services.Repositories
{
    public interface IInvoiceService
    {
        public IEnumerable<IGrouping<int, InvoicesByMatterDTO>> GetInvoicesByMatter();
        public Invoice AddInvoice(InvoiceDTO invoice);
        public IEnumerable<InvoicesForMatterDTO> GetInvoicesForMatter(int matterId);
        public IEnumerable<IGrouping<int, BillingsByAttorneyDTO>> GetLastWeekBillingsByAttorney();
        public IEnumerable<BillingsForAttorneyDTO> GetLastWeekBillingsForAttorney(int attorneyId);
        public double GetTotalBillingForAttorney(int attorneyId);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly LexiconDBContext _lexiconDBContext;
        private readonly IMapper _mapper;
        public InvoiceService(LexiconDBContext lexiconDBContext, IMapper mapper)
        {
            _lexiconDBContext = lexiconDBContext;
            _mapper = mapper;
        }

        public IEnumerable<IGrouping<int, InvoicesByMatterDTO>> GetInvoicesByMatter()
        {
          
            var invoiceList = _lexiconDBContext.Invoices
               .Include(m => m.Matter)
               .Include(m => m.Attorney)
               .Include(m => m.Matter.Client)
               .Select(c => new InvoiceByMatterMapper().Map(c)).AsEnumerable()
               .GroupBy(s => s.MatterId).ToList();
            return invoiceList;
        }

        public IEnumerable<IGrouping<int, BillingsByAttorneyDTO>> GetLastWeekBillingsByAttorney()
        {
            var dt = DateTime.Now.AddDays(-7);

            var invoiceList = _lexiconDBContext.Invoices.Where(c => c.Date > dt)
                .Include(m => m.Matter)
                .Include(m => m.Attorney)
                .Include(m => m.Matter.Client)
                .Select(c => new BillingsByAttorneyMapper().Map(c)).AsEnumerable()
                .GroupBy(s => s.AttorneyId).ToList();
            return invoiceList;
        }

        //public int TotalBillings(int attorneyId) 
        //{
        
        //}

        public IEnumerable<BillingsForAttorneyDTO> GetLastWeekBillingsForAttorney(int attorneyId)
        {
            var dt = DateTime.Now.AddDays(-7);

            var invoicesForAttorney = _lexiconDBContext.Invoices.Where(c => c.Date > dt)
                .Include(i => i.Matter)
                .Include(i => i.Matter.Client)
                .Include(i => i.Attorney)
                .Where(c => c.AttorneyId.Equals(attorneyId));
            return invoicesForAttorney.Select(c => new BillingsForAttorneyMapper().Map(c)).ToList();

        }

        public double GetTotalBillingForAttorney(int attorneyId)
        {
            var dt = DateTime.Now.AddDays(-7);

            double billing = Convert.ToDouble(_lexiconDBContext.Invoices.Where(c => c.Date > dt)
            .Sum(im => im.TotalAmount));
            return billing;
        }

        public Invoice AddInvoice(InvoiceDTO invoice)
        {
            try
            {
                Attorney attorney = _lexiconDBContext.Attorneys.FirstOrDefault(s => s.Id == invoice.AttorneyId);
                Matter matter = _lexiconDBContext.Matters.FirstOrDefault(s => s.Id == invoice.MatterId);

                if (invoice.AttorneyId == matter.BillingAttorneyId || invoice.AttorneyId == matter.ResponsibleAttorneyId)
                {
                    int invoiceTotalAmount = invoice.HoursWorked * attorney!.Rate;
                    var newInvoice = new Invoice
                    {
                        Date = invoice.Date,
                        HoursWorked = invoice.HoursWorked,
                        TotalAmount = invoiceTotalAmount,
                        MatterId = invoice.MatterId,
                        AttorneyId = invoice.AttorneyId,
                    };
                    _lexiconDBContext.Invoices.Add(newInvoice);
                    _lexiconDBContext.SaveChanges();
                    return newInvoice;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<InvoicesForMatterDTO> GetInvoicesForMatter(int matterId)
        {
            var invoicesByMatter = _lexiconDBContext.Invoices
                .Include(i => i.Matter)
                .Include(i => i.Matter.Client)
                .Include(i => i.Attorney)
                .Where(c => c.MatterId.Equals(matterId));
            return invoicesByMatter.Select(c => new InvoiceForMatterMapper().Map(c)).ToList();
        }

    }
}