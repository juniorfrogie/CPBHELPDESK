<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="pages_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta http-equiv="refresh" content="60">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">

    <%if(Session["UserLogin"]=="yang raksmey"){ %>
    <!-- Button trigger modal -->
        <button type="button" id="mybtn" style="display:none;" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
          Launch demo modal
        </button>

        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Hi, Bong Smey</h4>
              </div>
              <div class="modal-body">
                Please Don't forget to buy coffee to office, ok.
                <img src="../images/Angry-smiley.png"  width="500"/>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Ok I'll Rememeber it</button>                
              </div>
            </div>
          </div>
        </div>
    <%} %>


    <div class="col-lg-12" style="margin:20px;">


            <div>
                    <div class="panel panel-default" style="margin-top:20px;">
              <div class="panel-heading">
                <h3 class="panel-title">Pending Request</h3>
              </div>
              <div class="panel-body">                  
                   <div class="row">
                       <%
                           DataClassesDataContext dc = new DataClassesDataContext();
                           var query = dc.SELECT_REQUEST_2();
                           var q = query.OrderByDescending(o => o.req_no);

                           foreach (var x in q)
                           {
                               if (x.category == "solution" && x.user_action=="Pending")
                               {
                            %>
                             <div class="col-xs-4 col-md-2" >
                                <a data-toggle="tooltip" data-placement="right" title='<%Response.Write(x.req_no); %>' href='<% Response.Write(String.Concat("request_new.aspx?id=", x.req_no,"&action=pickup&ua=",x.user_action,"&sid=",x.requestor_id)); %>' class="thumbnail" style="height:100px;background:#33bbff;">
                                  <h4 style="margin-top:35px;margin-left:18px;"><%Response.Write(x.Location); %></h4>                                  
                                </a>
                              </div>
                       <%
                               }else if(x.category =="infra" && x.status=="Pending")
                               {
                            %>
                               <div class="col-xs-4 col-md-2">
                                <a data-toggle="tooltip" data-placement="right" title='<%Response.Write(x.req_no); %>' href='<% Response.Write(String.Concat("request_new.aspx?id=", x.req_no,"&action=pickup&ua=",x.user_action,"&sid=",x.requestor_id)); %>' class="thumbnail" style="height:100px;background:#ff9933;">
                                  <h4 style="margin-top:35px;margin-left:18px;"><% Response.Write(x.Location); %></h4>                                  
                                </a>
                              </div>
                       <%}
                           } %>
                    </div>
              </div>
            </div>
            </div>
    </div>



    <div class="col-lg-12" style="margin:20px;">


            <div>
                    <div class="panel panel-default" style="margin-top:20px;">
              <div class="panel-heading">
                <h3 class="panel-title">Pending Incident</h3>
              </div>
              <div class="panel-body">                  
                   <div class="row">
                       <%
                           
                           var query1 = dc.SELECT_INCIDENT();

                           foreach (var x in query1)
                           {
                               
                               if (x.status == "Pending")
                               {
                                   
                            %>                             
                               <div class="col-xs-4 col-md-2">
                                <a data-toggle="tooltip" data-placement="right" title='<%Response.Write(x.desc); %>' href='<% Response.Write(String.Concat("incident.aspx?id=", string.Format("{0:000000}", x.no), "&action=pickup")); %>' class="thumbnail" style="height:100px;background:#ff9933;">
                                  <h4 style="margin-top:35px;margin-left:18px;"><% Response.Write(x.catID_lvl1); %></h4>
                                </a>
                              </div>
                       <%
                               }
                           } %>
                    </div>
              </div>
            </div>
            </div>
    </div>
    
</div>
    <script>
        $(function () {
            $('#mybtn').click();
        });
    </script>
      
</asp:Content>

