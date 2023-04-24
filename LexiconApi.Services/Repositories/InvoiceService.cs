using AutoMapper;
using LexiconApi.Data.DBContext;
using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Mappers;


namespace LexiconApi.Services.Repositories
{
    public interface IInvoiceService
    {
        public IEnumerable<IGrouping<int, Invoice>> GetAllInvoices();
        public Invoice AddInvoice(InvoiceDTO invoice);
        public IEnumerable<InvoiceDTO> GetInvoicesForMatter(int matterId);
        public IEnumerable<IGrouping<int, Invoice>> GetLastWeekBillingsByAttorney();
        public IEnumerable<InvoiceDTO> GetLastWeekBillingsForAttorney(int attorneyId);
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

        public IEnumerable<IGrouping<int, Invoice>> GetAllInvoices()
        {
            IEnumerable<IGrouping<int, Invoice>> invoiceList = _lexiconDBContext.Invoices.GroupBy(s => s.MatterId).ToList();
            return invoiceList;
        }

        public IEnumerable<IGrouping<int, Invoice>> GetLastWeekBillingsByAttorney()
        {
            var dt = DateTime.Now.AddDays(-7);

            IEnumerable<IGrouping<int, Invoice>> invoiceList = _lexiconDBContext.Invoices.Where(c => c.Date > dt).GroupBy(s => s.AttorneyId).ToList();
            return invoiceList;

        }

        public IEnumerable<InvoiceDTO> GetLastWeekBillingsForAttorney(int attorneyId)
        {
            var dt = DateTime.Now.AddDays(-7);

            var invoicesForAttorney = _lexiconDBContext.Invoices.Where(c => c.Date > dt).Where(c => c.AttorneyId.Equals(attorneyId)).ToList();
            return invoicesForAttorney.Select(c => new InvoiceMapper().Map(c)).ToList();

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

        public IEnumerable<InvoiceDTO> GetInvoicesForMatter(int matterId)
        {
            var invoicesByMatter = _lexiconDBContext.Invoices.Where(c => c.MatterId.Equals(matterId));
            return invoicesByMatter.Select(c => new InvoiceMapper().Map(c)).ToList();
        }

    }
}