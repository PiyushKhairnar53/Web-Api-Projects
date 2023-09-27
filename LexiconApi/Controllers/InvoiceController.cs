using LexiconApi.Data.Models;
using LexiconApi.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/<AttorneyController>
        [HttpGet("InvoicesByMatter")]
        public IActionResult GetAllInvoices()
        {
            Response response;
            try
            {
                IEnumerable<IGrouping<int, InvoicesByMatterDTO>> invoices = _invoiceService.GetInvoicesByMatter();
                response = new Response(StatusCodes.Status200OK, "Invoices retreived successfully", invoices);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new Response(StatusCodes.Status400BadRequest, "Somethng went wrong" + ex.Message, null);
                return BadRequest(response);
            }
        }

        [HttpGet("BillingsByAttorney")]
        public IActionResult GetLastWeekBillingsByAttorney()
        {
            Response response;
            try
            {
                //return Ok(_invoiceService.GetLastWeekBillingsByAttorney());
                IEnumerable<IGrouping<int, BillingsByAttorneyDTO>> invoices = _invoiceService.GetLastWeekBillingsByAttorney();
                response = new Response(StatusCodes.Status200OK, "Invoices retreived successfully", invoices);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new Response(StatusCodes.Status400BadRequest, "Somethng went wrong" + ex.Message, null);
                return BadRequest(response);
            }
        }

        [HttpGet("BillingsForAttorney/{attorneyId}")]
        public IActionResult GetLastWeekBillingsForAttorney(int attorneyId)
        {
            Response response;
            try
            {
                //return Ok(_invoiceService.GetLastWeekBillingsForAttorney(attorneyId));
                IEnumerable<BillingsForAttorneyDTO> invoices = _invoiceService.GetLastWeekBillingsForAttorney(attorneyId);
                if (invoices.Any()) 
                {
                    response = new Response(StatusCodes.Status200OK, "Invoices For attorney retreived successfully", invoices);
                    return Ok(response);
                }
                response = new Response(StatusCodes.Status200OK, "Invoices not found for the attorney", null);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new Response(StatusCodes.Status400BadRequest, "Somethng went wrong" + ex.Message, null);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public IActionResult AddInvoice([FromBody] InvoiceDTO invoice)
        {
            invoice.Id = 0;
            Response response;
            try
            {
                if (invoice.Date != null && invoice.HoursWorked > 0)
                {
                    Invoice newInvoice = _invoiceService.AddInvoice(invoice);
                    if (newInvoice != null)
                    {
                        response = new Response(StatusCodes.Status200OK, "Invoice added successfully", newInvoice);
                        return Ok(response);
                    }
                }
                response = new Response(StatusCodes.Status400BadRequest, "Please eneter valid credentials", null);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new Response(StatusCodes.Status400BadRequest, "Somethng went wrong" + ex.Message, null);
                return BadRequest(response);
            }
        }

        [HttpGet("InvoicesForMatter/{matterId}")]
        public IActionResult GetInvoicesForMatter(int matterId)
        {
            Response response;
          
                if (matterId > 0)
                {
                    IEnumerable<InvoicesForMatterDTO> invoices = _invoiceService.GetInvoicesForMatter(matterId);
                    if (invoices.Any())
                    {
                        response = new Response(StatusCodes.Status200OK, "Invoices for matter retreived successfully", invoices);
                        return Ok(response);

                    }
                    response = new Response(StatusCodes.Status404NotFound, "This Matter has no invoices", "");
                    return NotFound(response);
                }
                
           
            response = new Response(StatusCodes.Status400BadRequest, "Something went wrong", null);
            return NotFound(response);
        }
    }
}
