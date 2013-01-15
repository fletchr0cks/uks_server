<<<<<<< HEAD
﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UK Sledge
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div style="text-align:center;padding-top:5px"><img  src="../../Content/headerlogo.png" /></div>
  <script type="text/javascript">
      $(document).bind("pageinit", function() {
          $(function() {
              FTLcheck();
          });
      });
    </script>
   
       <div id="map_msg" class="ui-bar ui-bar-b"></div>   
		<div id="map_overlay" style="z-index:5000;position:absolute;display:none;background-color:Gray;opacity:0.8;height:300px"><h4 style="text-align:center;padding-top:100px">Loading sites....</h4></div>
		<div id="map_canvas" style="height:300px;"></div>
       <div id="place_name" class="ui-bar ui-bar-b">&nbsp</div> 
       <div id="place_name2" class="ui-bar ui-bar-b" style="display:none"><div style="display:inline" id="comments_ct"></div></div> 
       <div id="place_comments" data-theme="b" style="display:none"></div>
       <div id="addcommentdiv" style="display:none">
       <ul data-role="listview" id="Ul1" data-inset="true">
<li>
<div><input type="text" name="addcomment" id="addcommentid" value="" /></div>
<div data-role="button" data-icon="delete" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="SaveComment()">Add Comment</div>
<div class="ui-grid-a"><div class="ui-block-a">
<h6>Flag site to Moderator:</h6>

<select data-mini="true" name="slider" id="sliderid" data-role="slider"  data-theme="a">
	<option value="no" selected="selected">No</option>
	<option value="yes" >Yes</option>
</select>
</div>
<div class="ui-block-b"><p>&nbsp;</p>
<div data-role="button" data-icon="delete" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="HideComments()">Hide Comments</div>
</div>
</li>
</ul>
</div>
<div data-role="collapsible" class="ui-disabled" data-theme="a" data-inset="true" data-content-theme="a" id="add_site">
		<h4>Add Site</h4>
	<div id="saveSite" class="ui-bar ui-bar-b">Lat: <div style="display:inline" id="lat_coord"></div>   Long:<div style="display:inline" id="long_coord"></div></div> 
	<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Site Name</div>
	<div class="ui-block-b"><input type="text" name="sitename" id="sitenameid" value="" /></div>
	</div>
	<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Comment</div>
	<div class="ui-block-b"><input type="text" name="comment" id="commentid" value="" /></div>
	</div>
		<div id="saveSiteBtn"><div data-role="button" data-icon="delete" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="saveSite1()">Save</div></div>
		
	 </div>
<div data-role="collapsible" class="ui-disabled" data-theme="a" data-inset="true" data-content-theme="a" id="my_sites">
<h4>My Sites <div id="my_sites_ct" style="display:inline" class="ui-li-count">(0)</div></h4>
<div id="sites_msg" class="ui-bar ui-bar-b"></div>   
       <div id="sites_list" data-theme="b"></div>
</div>
	
<div data-role="collapsible" data-theme="a" data-inset="true" data-content-theme="a" id="search_id">
		<h4>Search</h4>
         <div class="ui-grid-a">
	<div class="ui-block-a"><input type="text" name="search" id="searchid" value="" /></div>
	<div class="ui-block-b"><div data-role="button" data-icon="search" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="doSearch()">Search</div></div>
	</div>
	 <div id="sites_search_msg" class="ui-bar ui-bar-b" style="display:none"></div>   
       <div id="sites_search_list"></div>
	 </div>

<div data-role="collapsible" data-theme="a" data-inset="true" data-content-theme="a">
		<h4>Hourly Weather<div style="display:inline" id="snowfall"></div></h4>
	<canvas id="canvhere" width="450" height="2000">text here eq no canvas</canvas>
	 </div>

<ul data-role="listview" data-inset="true">
<li><p class="ui-li-aside"><a href="/Home/About" data-rel="page" data-transition="flip" data-inline="true" data-icon="gear" data-theme="b" data-role="button" data-mini="true">Edit</a></p>
<h3>My Details</h3>
<p>&nbsp;</p>
<p>My Location: <span id="loc_here"></span></p>
<p>Name: <span id="phone_name"></span><div style="display:inline;color:#66A68B" id="name_msg"></div></p>
</li>
</ul>


<ul data-role="listview" id="status" data-inset="true">
<li><p class="ui-li-aside"><a href="#" data-role="button" data-inline="true" data-icon="gear" data-theme="b" data-role="button" data-mini="true" onclick="load_data_db()">Refresh</a></p>
<h3>Status</h3>
<div id="statustxt"><p>Total sites: <span id="total_sites"></span></p>
<p>Latest site added by <span id="lat_nm"></span> in <span id="lat_tn"></span></p></div>
</li>
</ul>
<div id="twitter_div" onclick="nuke()">
<a class="twitter-timeline" href="https://twitter.com/uksledge" data-widget-id="273815461060284417">Tweets by @uksledge</a>
<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src="//platform.twitter.com/widgets.js";fjs.parentNode.insertBefore(js,fjs);}}(document,"script","twitter-wjs");</script>
</div>
<h6 id="data_status" onclick="nuke()"></h6>
		
</asp:Content>
=======
﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UK Sledge
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div style="text-align:center;padding-top:5px"><img  src="../../Content/headerlogo.png" /></div>
  <script type="text/javascript">
      $(document).bind("pageinit", function() {
          $(function() {
              FTLcheck();
          });
      });
    </script>
   
       <div id="map_msg" class="ui-bar ui-bar-b"></div>   
		<div id="map_overlay" style="z-index:5000;position:absolute;display:none;background-color:Gray;opacity:0.8;height:300px"><h4 style="text-align:center;padding-top:100px">Loading sites....</h4></div>
		<div id="map_canvas" style="height:300px;"></div>
       <div id="place_name" class="ui-bar ui-bar-b">&nbsp</div> 
       <div id="place_name2" class="ui-bar ui-bar-b" style="display:none"><div style="display:inline" id="comments_ct"></div></div> 
       <div id="place_comments" data-theme="b" style="display:none"></div>
       <div id="addcommentdiv" style="display:none">
       <ul data-role="listview" id="Ul1" data-inset="true">
<li>
<div><input type="text" name="addcomment" id="addcommentid" value="" /></div>
<div data-role="button" data-icon="delete" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="SaveComment()">Add Comment</div>
<div class="ui-grid-a"><div class="ui-block-a">
<h6>Flag site to Moderator:</h6>

<select data-mini="true" name="slider" id="sliderid" data-role="slider"  data-theme="a">
	<option value="no" selected="selected">No</option>
	<option value="yes" >Yes</option>
</select>
</div>
<div class="ui-block-b"><p>&nbsp;</p>
<div data-role="button" data-icon="delete" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="HideComments()">Hide Comments</div>
</div>
</li>
</ul>
</div>
<div data-role="collapsible" class="ui-disabled" data-theme="a" data-inset="true" data-content-theme="a" id="add_site">
		<h4>Add Site</h4>
	<div id="saveSite" class="ui-bar ui-bar-b">Lat: <div style="display:inline" id="lat_coord"></div>   Long:<div style="display:inline" id="long_coord"></div></div> 
	<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Site Name</div>
	<div class="ui-block-b"><input type="text" name="sitename" id="sitenameid" value="" /></div>
	</div>
	<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Comment</div>
	<div class="ui-block-b"><input type="text" name="comment" id="commentid" value="" /></div>
	</div>
		<div id="saveSiteBtn"><div data-role="button" data-icon="delete" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="saveSite1()">Save</div></div>
		
	 </div>
<div data-role="collapsible" class="ui-disabled" data-theme="a" data-inset="true" data-content-theme="a" id="my_sites">
<h4>My Sites <div id="my_sites_ct" style="display:inline" class="ui-li-count">(0)</div></h4>
<div id="sites_msg" class="ui-bar ui-bar-b"></div>   
<div id="saveSitem" style="display:none" class="ui-bar ui-bar-b">Lat: <div style="display:inline" id="lat_coordm"></div>   Long:<div style="display:inline" id="long_coordm"></div><div style="display:inline"> Site ID: </div><div style="display:inline" id="MPID"></div></div> 
<div id="saveMovedSite" style="display:none"><div data-role="button" data-icon="delete" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" data-direction="reverse" onclick="saveMovedSite()">Save</div></div>
<div id="sites_list" data-theme="b"></div>
</div>
	
<div data-role="collapsible" data-theme="a" data-inset="true" data-content-theme="a" id="search_id">
		<h4>Search</h4>
         <div class="ui-grid-a">
	<div class="ui-block-a"><input type="text" name="search" id="searchid" value="" /></div>
	<div class="ui-block-b"><div data-role="button" data-icon="search" data-iconpos="left" data-mini="true" data-theme="b" data-inline="true" onclick="doSearch()">Search</div></div>
	</div>
	 <div id="sites_search_msg" class="ui-bar ui-bar-b" style="display:none"></div>   
       <div id="sites_search_list"></div>
	 </div>

<div data-role="collapsible" data-theme="a" data-inset="true" data-content-theme="a">
		<h4>Hourly Weather<div style="display:inline" id="snowfall"></div></h4>
	<canvas id="canvhere" width="450" height="2000">text here eq no canvas</canvas>
	 </div>

<ul data-role="listview" data-inset="true">
<li><p class="ui-li-aside"><a href="/Home/About" data-rel="page" data-transition="flip" data-inline="true" data-icon="gear" data-theme="b" data-role="button" data-mini="true">Edit</a></p>
<h3>My Details</h3>
<p>&nbsp;</p>
<p>My Location: <span id="loc_here"></span></p>
<p>Name: <span id="phone_name"></span><div style="display:inline;color:#66A68B" id="name_msg"></div></p>
</li>
</ul>


<ul data-role="listview" id="status" data-inset="true">
<li><p class="ui-li-aside"><a href="#" data-role="button" data-inline="true" data-icon="gear" data-theme="b" data-role="button" data-mini="true" onclick="load_data_db()">Refresh</a></p>
<h3>Status</h3>
<div id="statustxt"><p>Total sites: <span id="total_sites"></span></p>
<p>Latest site added by <span id="lat_nm"></span> in <span id="lat_tn"></span></p></div>
</li>
</ul>
<div id="twitter_div">
<a class="twitter-timeline" href="https://twitter.com/uksledge" data-widget-id="273815461060284417">Tweets by @uksledge</a>
<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src="//platform.twitter.com/widgets.js";fjs.parentNode.insertBefore(js,fjs);}}(document,"script","twitter-wjs");</script>
</div>

<div data-role="collapsible" data-theme="a" data-inset="true" data-content-theme="a" id="credits">
		<h4>Credits</h4>
         <p>This site would not be possible without all the great free APIs and technologies from:</p>
  <div style="text-align:center"><img style="width:300px" src="../../Content/logos2.png" /></div>
	  <div><a href="mailto:mistersledge@mail.com?Subject=Contact%20from%20site">Contact me at mistersledge@mail.com</a></div>

	 </div>

<div data-role="collapsible" data-theme="a" data-inset="true" data-content-theme="a" id="app">
		<h4>Android App</h4>
         <p>Get the UK Sledge app from the Google Play Store. </p>
	 </div>

<h6 id="data_statusqqq" onclick="nukeo()"></h6>
		
</asp:Content>
>>>>>>> tues1
