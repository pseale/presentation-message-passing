using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//hello, I made this entire chunk of code to generate a sequence diagram. I really hate drawing diagrams from scratch.
namespace MessagePassingDemoSnippets
{
  public class Payola
  {
    public void CallingCode()
    {
      var invoiceData = new InvoiceData { InvoiceAmount = 50m };
      var webServiceClient = new Umweltverschmutzung();
      SendInvoiceData(invoiceData, webServiceClient);
    }
    public void SendInvoiceData(InvoiceData invoiceData, Umweltverschmutzung webServiceClient)
    {
      try 
      { 
        var response = webServiceClient.ReceiveInvoiceData(invoiceData);
      }
      catch (Exception e)
      {
        Logger.Log("Error: " + e.ToString());
      }
    }
  }

  public class Umweltverschmutzung
  {
    SAP _sap = new SAP();
    public HttpResponse ReceiveInvoiceData(InvoiceData invoiceData)
    {
      _sap.StoreInvoiceData(invoiceData);
      return HttpResponse.Ok;
    }
  }

  public class SAP
  {
    public void StoreInvoiceData(InvoiceData invoiceData)
    {
    }
  }

  public class InvoiceData
  {
    public decimal InvoiceAmount { get; set; }
  }

  public static class Logger
  {
    public static void Log(string message)
    {

    }
  }

  public class HttpResponse
  {
    public static readonly HttpResponse Ok = new HttpResponse("200 OK");
    public HttpResponse(string responseString)
    {

    }
  }
}
