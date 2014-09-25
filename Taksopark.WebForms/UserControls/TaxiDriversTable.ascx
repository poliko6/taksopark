﻿<%@ Control Language="C#" AutoEventWireup="true" EnableTheming="true" CodeBehind="TaxiDriversTable.ascx.cs" Inherits="Taksopark.WebForms.UserControls.TaxiDriversTable" %>
<link href="../Styles/AdminStyles.css" rel="stylesheet" />
<div>
    <asp:GridView runat="server" ID="TaxiDriversGV" AllowPaging="true" PageSize="20"
        OnPageIndexChanging="TaxiDriversGV_PageIndexChanging" DataSourceID="allTaxiDriversDS"
        AutoGenerateColumns="false" OnRowCommand="TaxiDriversGV_RowCommand">
        <Columns>
            <%--<asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Select" ControlStyle-ForeColor="Red" />
            <asp:ButtonField HeaderText="More info" Text="More..." ControlStyle-ForeColor="Blue" />--%>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text="Edit"
                        NavigateUrl='<%# "~/WebForms/EditTaxiDriver.aspx?id=" + Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="User">
                <ItemTemplate>
                    <%# String.Format("{0}"+" "+"{1}",Eval("UserName"),Eval("LastName"))  %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Login">
                <ItemTemplate>
                    <%# Eval("Login") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Phone Number">
                <ItemTemplate>
                    <%# Eval("PhoneNumber") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <%# Eval("Email") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Car">
                <ItemTemplate>
                    <%# String.Format("{0}"+", "+"{1}", Eval("Car.CarBrand"), Eval("Car.CarYear"))  %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Work Time">
                <ItemTemplate>
                    <%# String.Format("{0}"+" - "+"{1}", DateTime.Parse(Eval("Car.StartWorkTime").ToString()).ToShortTimeString(), DateTime.Parse(Eval("Car.FinishWorkTime").ToString()).ToShortTimeString()) %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%# Eval("Status") %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <HeaderStyle CssClass="gvHeader" />
        <SelectedRowStyle CssClass="gvSelectedRow" />
    </asp:GridView>
</div>