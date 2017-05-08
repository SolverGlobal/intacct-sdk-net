﻿/*
 * Copyright 2017 Intacct Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using Intacct.Sdk.Tests.Helpers;
using Intacct.Sdk.Xml;
using System.Collections.Generic;
using Intacct.Sdk.Functions.AccountsReceivable;
using Org.XmlUnit.Diff;
using Org.XmlUnit.Builder;

namespace Intacct.Sdk.Tests.Functions.AccountsReceivable
{

    [TestClass]
    public class CustomerUpdateTest
    {

        [TestMethod()]
        public void GetXmlTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<function controlid=""unittest"">
    <update>
        <CUSTOMER>
            <CUSTOMERID>C1234</CUSTOMERID>
            <DISPLAYCONTACT />
        </CUSTOMER>
    </update>
</function>";

            Stream stream = new MemoryStream();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Encoding = Encoding.UTF8;
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = "    ";

            IaXmlWriter xml = new IaXmlWriter(stream, xmlSettings);

            CustomerUpdate record = new CustomerUpdate("unittest");
            record.CustomerId = "C1234";

            record.WriteXml(ref xml);

            xml.Flush();
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);

            Diff xmlDiff = DiffBuilder.Compare(expected).WithTest(reader.ReadToEnd())
                .WithDifferenceEvaluator(DifferenceEvaluators.Default)
                .Build();
            Assert.IsFalse(xmlDiff.HasDifferences(), xmlDiff.ToString());
        }

        [TestMethod()]
        public void GetAllXmlTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<function controlid=""unittest"">
    <update>
        <CUSTOMER>
            <CUSTOMERID>C1234</CUSTOMERID>
            <NAME>Intacct Corp</NAME>
            <DISPLAYCONTACT>
                <PRINTAS>Intacct Corporation</PRINTAS>
                <COMPANYNAME>Intacct Corp.</COMPANYNAME>
                <TAXABLE>true</TAXABLE>
                <TAXGROUP>CA</TAXGROUP>
                <PREFIX>Mr</PREFIX>
                <FIRSTNAME>Bill</FIRSTNAME>
                <LASTNAME>Smith</LASTNAME>
                <INITIAL>G</INITIAL>
                <PHONE1>12</PHONE1>
                <PHONE2>34</PHONE2>
                <CELLPHONE>56</CELLPHONE>
                <PAGER>78</PAGER>
                <FAX>90</FAX>
                <EMAIL1>noreply@intacct.com</EMAIL1>
                <EMAIL2>noreplyagain@intacct.com</EMAIL2>
                <URL1>www.intacct.com</URL1>
                <URL2>us.intacct.com</URL2>
                <MAILADDRESS>
                    <ADDRESS1>300 Park Ave</ADDRESS1>
                    <ADDRESS2>Ste 1400</ADDRESS2>
                    <CITY>San Jose</CITY>
                    <STATE>CA</STATE>
                    <ZIP>95110</ZIP>
                    <COUNTRY>United States</COUNTRY>
                </MAILADDRESS>
            </DISPLAYCONTACT>
            <ONETIME>false</ONETIME>
            <STATUS>active</STATUS>
            <HIDEDISPLAYCONTACT>false</HIDEDISPLAYCONTACT>
            <CUSTTYPE>SaaS</CUSTTYPE>
            <PARENTID>C5678</PARENTID>
            <GLGROUP>Group</GLGROUP>
            <TERRITORYID>NE</TERRITORYID>
            <SUPDOCID>A1234</SUPDOCID>
            <TERMNAME>N30</TERMNAME>
            <OFFSETGLACCOUNTNO>1200</OFFSETGLACCOUNTNO>
            <ARACCOUNT>4000</ARACCOUNT>
            <SHIPPINGMETHOD>USPS</SHIPPINGMETHOD>
            <RESALENO>123</RESALENO>
            <TAXID>12-3456789</TAXID>
            <CREDITLIMIT>1234.56</CREDITLIMIT>
            <ONHOLD>false</ONHOLD>
            <DELIVERYOPTIONS>Print#~#E-Mail</DELIVERYOPTIONS>
            <CUSTMESSAGEID>hello</CUSTMESSAGEID>
            <COMMENTS>my comment</COMMENTS>
            <CURRENCY>USD</CURRENCY>
            <ARINVOICEPRINTTEMPLATEID>temp1</ARINVOICEPRINTTEMPLATEID>
            <OEQUOTEPRINTTEMPLATEID>temp2</OEQUOTEPRINTTEMPLATEID>
            <OEORDERPRINTTEMPLATEID>temp3</OEORDERPRINTTEMPLATEID>
            <OELISTPRINTTEMPLATEID>temp4</OELISTPRINTTEMPLATEID>
            <OEINVOICEPRINTTEMPLATEID>temp5</OEINVOICEPRINTTEMPLATEID>
            <OEADJPRINTTEMPLATEID>temp6</OEADJPRINTTEMPLATEID>
            <OEOTHERPRINTTEMPLATEID>temp7</OEOTHERPRINTTEMPLATEID>
            <CONTACTINFO>
                <CONTACTNAME>primary</CONTACTNAME>
            </CONTACTINFO>
            <BILLTO>
                <CONTACTNAME>bill to</CONTACTNAME>
            </BILLTO>
            <SHIPTO>
                <CONTACTNAME>ship to</CONTACTNAME>
            </SHIPTO>
            <OBJECTRESTRICTION>Restricted</OBJECTRESTRICTION>
            <RESTRICTEDLOCATIONS>100#~#200</RESTRICTEDLOCATIONS>
            <RESTRICTEDDEPARTMENTS>D100#~#D200</RESTRICTEDDEPARTMENTS>
            <CUSTOMFIELD1>Hello</CUSTOMFIELD1>
        </CUSTOMER>
    </update>
</function>";

            Stream stream = new MemoryStream();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Encoding = Encoding.UTF8;
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = "    ";

            IaXmlWriter xml = new IaXmlWriter(stream, xmlSettings);

            CustomerUpdate record = new CustomerUpdate("unittest") {
                CustomerId = "C1234",
                CustomerName = "Intacct Corp",
                PrintAs = "Intacct Corporation",
                CompanyName = "Intacct Corp.",
                Taxable = true,
                TaxId = "12-3456789",
                ContactTaxGroupName = "CA",
                Prefix = "Mr",
                FirstName = "Bill",
                LastName = "Smith",
                MiddleName = "G",
                PrimaryPhoneNo = "12",
                SecondaryPhoneNo = "34",
                CellularPhoneNo = "56",
                PagerNo = "78",
                FaxNo = "90",
                PrimaryEmailAddress = "noreply@intacct.com",
                SecondaryEmailAddress = "noreplyagain@intacct.com",
                PrimaryUrl = "www.intacct.com",
                SecondaryUrl = "us.intacct.com",
                AddressLine1 = "300 Park Ave",
                AddressLine2 = "Ste 1400",
                City = "San Jose",
                StateProvince = "CA",
                ZipPostalCode = "95110",
                Country = "United States",
                OneTime = false,
                Active = true,
                ExcludedFromContactList = false,
                CustomerTypeId = "SaaS",
                ParentCustomerId = "C5678",
                GlGroupName = "Group",
                TerritoryId = "NE",
                AttachmentsId = "A1234",
                PaymentTerm = "N30",
                OffsetArGlAccountNo = "1200",
                DefaultRevenueGlAccountNo = "4000",
                ShippingMethod = "USPS",
                ResaleNumber = "123",
                CreditLimit = 1234.56M,
                OnHold = false,
                DeliveryMethod = "Print#~#E-Mail",
                DefaultInvoiceMessage = "hello",
                Comments = "my comment",
                DefaultCurrency = "USD",
                PrintOptionArInvoiceTemplateName = "temp1",
                PrintOptionOeQuoteTemplateName = "temp2",
                PrintOptionOeOrderTemplateName = "temp3",
                PrintOptionOeListTemplateName = "temp4",
                PrintOptionOeInvoiceTemplateName = "temp5",
                PrintOptionOeAdjustmentTemplateName = "temp6",
                PrintOptionOeOtherTemplateName = "temp7",
                PrimaryContactName = "primary",
                BillToContactName = "bill to",
                ShipToContactName = "ship to",
                RestrictionType = "Restricted",
                RestrictedLocations = new List<string>()
                {
                    "100",
                    "200",
                },
                RestrictedDepartments = new List<string>()
                {
                    "D100",
                    "D200",
                },
                CustomFields = new Dictionary<string, dynamic>
                {
                    { "CUSTOMFIELD1", "Hello" }
                }
            };

            record.WriteXml(ref xml);

            xml.Flush();
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);

            Diff xmlDiff = DiffBuilder.Compare(expected).WithTest(reader.ReadToEnd())
                .WithDifferenceEvaluator(DifferenceEvaluators.Default)
                .Build();
            Assert.IsFalse(xmlDiff.HasDifferences(), xmlDiff.ToString());
        }

    }

}
