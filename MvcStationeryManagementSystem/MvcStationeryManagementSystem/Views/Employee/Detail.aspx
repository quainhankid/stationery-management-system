﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Template.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcStationeryManagementSystem.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm("Detail", "Employee"))
        {%>
    <%  Employee em = (Employee)ViewData["ct"]; %>
    
    
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all form-container">
					<div class="portlet-header ui-widget-header"><span class="ui-icon ui-icon-circle-arrow-s"></span>Form registering employee</div>
					<div class="mydiv1">
					    <div class="portlet-content-new" style="display: block;">
							<ul>
							    <li>
							        <label class="desc">
							            EmployeeNumber
							        </label>
							        <div>
							        <input type="text" name="DateBirth" id="EmployeeNumber" class="field text medium" value="<%= em.EmployeeNumber %>" readonly="readonly" size="2" maxlength="50" tabindex="1" />
							        </div>
							    </li>
								<li>
									<label class="desc">
										FullName
									</label>
									<div>
									<input type="text" name="DateBirth" id="FullName" class="field text medium" value="<%= em.FullName %>" readonly="readonly" size="2" maxlength="50" tabindex="2" />
									</div>
								</li>
								<li class="date">
									<label class="desc" id="title2" for="Field2">
										DateBirth
									</label>
										<input type="text" name="DateBirth" id="datebirth" class="field text medium" value="<%= em.DateBirth %>" readonly="readonly" size="2" maxlength="50" tabindex="3" />
										
								</li>
								<li>
									<label class="desc">
										Email
									</label>
									<div>
										<input type="text" name="Email" id="Email" class="field text medium" value="<%= em.Email %>" readonly="readonly" maxlength="255" tabindex="4" />
										
									</div>
								</li>
								<li>
									<label class="desc">
										Address
									</label>
									<div>
										<input type="text" name="Address" id="Address" class="field text medium" value="<%= em.Address %>" readonly="readonly" maxlength="255" tabindex="5" />
										
									</div>
								</li>
								<li>
									<label class="desc">
										Phone
									</label>
									<div>
										<input type="text" name="Phone" id="Phone" class="field text medium" value="<%=em.Phone %>" readonly="readonly" rows="5" cols="50" tabindex="6" />
									</div>
								</li>
								<li>
									<label class="desc">
										Role Id
									</label>
									<div class=desc>
									
									    <input type="text" name="roleid" id="RoleID" class="field text medium" value="<%= em.RoleId %>" readonly="readonly" tabindex="7" />
									</div>
									<%--%>
									
									<div class="float-left">
										<select tabindex="3" class="field select large" name="RoleId" >
										 <% foreach(Role ro in (List<Role>)ViewData["dsrole"]){%>
										    <option value="<%=ro.RoleId%>">
												<%=ro.RoleName%>
												
											</option>
										 <%}%>
											
										</select>
									
									</div>--%>
									
								</li>
								
								
								<li>
									<label class="desc" id="title4" for="Field4">
										RegistrationNumber
									</label>
									<div class="col">
										<input type="text" name="RegistrationNumber" id="RegistrationNumber" value="<%= em.RegistrationNumber %>" readonly="readonly" class="field text medium" readonly="readonly" tabindex="9" />
									</div>
								</li>
								<li>
								<a>
									<%= Html.ActionLink("Manage Employee ►►", "ManageEmployee", "Employee") %>
								</a>    
								</li>
							</ul>
					
					</div>
					</div>
				</div>
            <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="css" runat="server">
</asp:Content>
