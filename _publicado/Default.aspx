<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ContableWeb.Master" CodeBehind="Default.aspx.vb" Inherits="ContableWeb._Default" 

    title="Sistema Contable" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitulo" runat="server">Sistema Contable AAT </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentCuerpo" runat="server">


<div class="content widgetgrid">
<script type="text/javascript" src="./js/custom/widgets.js"></script>        	
					<div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="tabbed"><span>Latest Announcement</span></h2></div>
                        <div class="widgetcontent announcement">
                            <p>
                            <span class="radius2">Jan 19, 2012</span> <br />Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium.</p>
                            <p>
                            <span class="radius2">Jan 18, 2012</span> <br />Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo.</p>
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="tabbed"><span>Statements</span></h2></div>
                        <div class="widgetcontent padding0 statement">
                           <table cellpadding="0" cellspacing="0" border="0" class="stdtable">
                                <colgroup>
                                    <col class="con0" />
                                    <col class="con1" />
                                    <col class="con0" />
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th class="head0">Date</th>
                                        <th class="head1">Sales</th>
                                        <th class="head0">Earnings</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>01/12/12</td>
                                        <td>10</td>
                                        <td>$250.12</td>
                                    </tr>
                                    <tr>
                                        <td>01/11/12</td>
                                        <td>5</td>
                                        <td>$100.43</td>
                                    </tr>
                                    <tr>
                                        <td>01/10/12</td>
                                        <td>22</td>
                                        <td>$1010.00</td>
                                    </tr>
                                    <tr>
                                        <td>01/09/12</td>
                                        <td>21</td>
                                        <td>$1000.23</td>
                                    </tr>
                                    <tr>
                                        <td>01/08/12</td>
                                        <td>14</td>
                                        <td>$500.22</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="tabbed"><span>Recent Activity</span></h2></div>
                        <div class="widgetcontent padding0">
                            <ul class="activitylist">
                            	<li class="message"><a href=""><strong>John Doe</strong> sent a message <span>Just now</span></a></li>
                                <li class="user"><a href=""><strong>Paran Meller</strong> added <strong>23 users</strong> <span>Yesterday</span></a></li>
                                <li class="user"><a href=""><strong>Owen Lee</strong> added <strong>2 users</strong> <span>2 days ago</span></a></li>
                                <li class="message"><a href=""><strong>Jane Call</strong> sent a message <span>5 days ago</span></a></li>
                                <li class="media"><a href=""><strong>George Turk</strong> uploaded <strong>2 photos</strong> <span>5 days ago</span></a></li>
                            </ul>
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="calendar"><span>Event Calendar</span></h2></div>
                        <div class="widgetcontent padding0">
                            <div id="datepicker"></div>
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="general"><span>Recent Users</span></h2></div>
                        <div class="widgetcontent userlistwidget">
                            <ul>
                            	<li>
                                	<div class="avatar"><img src="./images/avatar2.png" alt="" /></div>
                                    <div class="info">
                                    	<a href="">Billie Norris</a> <br />
                                        Software Engineer <br /> 18 minutes ago
                                    </div><!--info-->
                                </li>
                                <li>
                                	<div class="avatar"><img src="./images/avatar2.png" alt="" /></div>
                                    <div class="info">
                                    	<a href="">Billie Norris</a> <br />
                                        Software Engineer <br /> 18 minutes ago
                                    </div><!--info-->
                                </li>
                            </ul>
                            <br clear="all" />
                            <a href="" class="more">View More Users</a>
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="general"><span>Form Widget</span></h2></div>
                        <div class="widgetcontent stdform stdformwidget">
                            <div class="par">
                            	<label>Account ID</label>
                                <div class="field">
                                	<input type="text" name="id" class="longinput" />
                                </div>
                            </div><!--par-->
                            <div class="par">
                            	<label>Amount</label>
                                <div class="field">
                                	<input type="text" name="id" class="longinput" /> <br />
                                    <small>Some description here</small>
                                </div>
                            </div><!--par-->
                            <div class="par">
                                <div class="field">
                                	<button class="radius2">Send</button>
                                </div>
                            </div><!--par-->
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="tabbed"><span>Tabbed Widget</span></h2></div>
                        <div class="widgetcontent padding0">
                            <div id="tabs">
                                <ul>
                                    <li><a href="#tabs-1">Products</a></li>
                                    <li><a href="#tabs-2">Posts</a></li>
                                    <li><a href="#tabs-3">Media</a></li>
                                </ul>
                                <div id="tabs-1">
                                    <ul class="listthumb">
                                        <li><img src="./images/thumb/small/thumb1.png" alt="" /> <a href="">Proin elit arcu, rutrum commodo</a></li>
                                        <li><img src="./images/thumb/small/thumb2.png" alt="" /> <a href="">Aenean tempor ullamcorper leo</a></li>
                                        <li><img src="./images/thumb/small/thumb3.png" alt="" /> <a href="">Vehicula tempus, commodo a, risus</a></li>
                                        <li><img src="./images/thumb/small/thumb4.png" alt="" /> <a href="">Donec sollicitudin mi sit amet mauris</a></li>
                                        <li><img src="./images/thumb/small/thumb5.png" alt="" /> <a href="">Curabitur nec arcu</a></li>
                                    </ul>
                                </div>
                                <div id="tabs-2">
                                    <ul>
                                        <li><a href="">Proin elit arcu, rutrum commodo</a></li>
                                        <li><a href="">Aenean tempor ullamcorper leo</a></li>
                                        <li><a href="">Vehicula tempus, commodo a, risus</a></li>
                                        <li><a href="">Donec sollicitudin mi sit amet mauris</a></li>
                                        <li><a href="">Curabitur nec arcu</a></li>
                                    </ul>
                                </div>
                                <div id="tabs-3">
                                    <ul class="thumb">
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb1.png" alt="" /></a></li>
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb2.png" alt="" /></a></li>
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb3.png" alt="" /></a></li>
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb4.png" alt="" /></a></li>
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb5.png" alt="" /></a></li>
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb6.png" alt="" /></a></li>
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb7.png" alt="" /></a></li>
                                        <li><a href="#"><img src="./images/thumb/xsmall/thumb8.png" alt="" /></a></li>
                                    </ul>     
                                </div>
                            </div><!--#tabs-->
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    
                    
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="chart"><span>Visitors Overview</span></h2></div>
                        <div class="widgetcontent chartbox">
                            <div id="chartplace" style="height: 118px"></div>
                            
                            <div class="one_half">
                                <div class="analytics analytics2">
                                    <small>Visitors For Today</small>
                                    <h1>23 321</h1>
                                    <small>18,222 unique</small>
                                </div><!--visitoday-->
                            </div><!--one_half-->
                            
                            <div class="one_half last">
                                
                                <div class="one_half">
                                    <div class="analytics">
                                        <small>bounce</small>
                                        <h3>23.2%</h3>
                                    </div><!--analytics-->
                                </div><!--one_half-->
                                
                                <div class="one_half last">
                                    <div class="analytics textright">
                                        <small class="block">visitors</small>
                                        <h3>56.8%</h3>
                                    </div><!--analytics-->
                                </div><!--one_half last-->
                                <br clear="all" />
                                
                                <div class="analytics average margintop10">
                                    Average <h3>87.44%</h3>
                                </div><!--analytics-->
                                
                            </div><!--one_half-->
                            
                            
                            <br clear="all" />
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->

                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="general"><span>Una nueva ventanita</span></h2></div>
                        <div class="widgetcontent">
                        Hola!!!
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="general"><span>Una nueva ventanita</span></h2></div>
                        <div class="widgetcontent">
                        Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />Hola!!!<br />
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->
                    <div class="widgetbox" style="width: 300px">
                        <div class="title"><h2 class="general"><span>Una nueva ventanita</span></h2></div>
                        <div class="widgetcontent">
                        Hola!!!
                        </div><!--widgetcontent-->
                    </div><!--widgetbox-->                    
                </div><!--content-->


</asp:Content>
