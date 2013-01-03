<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <script type="text/javascript">
     $(document).bind("pageinit", function () {
         $(function () {
             Edit();
         });
     });
    </script>
<div data-role="content" data-theme="a">

<div><h3>Location: <div style="display:inline" id="gps_results"></div></h3></div>
<div data-theme="b" data-role="button" onclick="refreshGPSLocation()">Get position from GPS</div>
<p></p>
<div class="ui-grid-a">
	<div class="ui-block-a"><h5>Or, enter your UK postcode:</h5></label><div id="pc_results"></div></div>
	<div class="ui-block-b" id="pc_search_btn"><input data-theme="c" type="search" name="pc" id="postcode" value=""/><div data-theme="b" id="set_pc" data-role="button" onclick="setPC()"> Search </div></div>
</div>

<p></p>

<div><h3>Login Details:</h3></div>
<div id="loginmsg"></div>
<div id="loginBtns">
<div class="ui-grid-a">
	<div class="ui-block-a"><div data-role="button" data-mini="true" data-theme="b" data-inline="true" onclick="Login()">Login</div></div>
	<div class="ui-block-b"><div data-role="button" data-mini="true" data-theme="b" data-inline="true" onclick="newLogin()">Create User</div></div>
	</div>
</div>
<div id="doLogin">
<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Name</div>
	<div class="ui-block-b"><input type="text" name="username" id="loginnameID" value="" /></div>
	</div>
	<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Password</div>
	<div class="ui-block-b"><input type="text" name="pass" id="loginpassID" value="" /></div>
	</div>
	<div>
    <div class="ui-grid-a">
	<div class="ui-block-a"></div>
	<div class="ui-block-b"><div data-role="button" data-mini="true" data-theme="b" data-inline="true" onclick="saveLogin()">Login</div></div>
	</div>
    </div>
</div>
<div id="setLogin">
<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Name</div>
	<div class="ui-block-b"><input type="text" name="username" id="usernameid" value="" /></div>
	</div>
	<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Password</div>
	<div class="ui-block-b"><input type="text" name="pass" id="passid" value="" /></div>
	</div>
    <div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Confirm Password</div>
	<div class="ui-block-b"><input type="text" name="pass2" id="passid2" value="" /></div>
	</div>
    <div>
    <div class="ui-grid-a">
	<div class="ui-block-a"></div>
	<div class="ui-block-b"><div data-role="button" data-mini="true" data-theme="b" data-inline="true" onclick="saveNewLogin()">Save</div></div>
	</div>
    </div>
</div>
<div id="changelogin">
<div class="ui-grid-a">
	<div class="ui-block-a"><h4>Name: <div style="display:inline" id="phonename"></div></h4></div>
	<div class="ui-block-b"><div data-theme="b" data-role="button" onclick="changeName()">Change Name</div><div data-theme="b" data-role="button" onclick="changePass()">Change Password</div></div>
	</div>
</div>

<div id="changeName">
<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>New Name:</div>
	<div class="ui-block-b"><input type="text" name="newname" id="newnameID" value="" /></div>
	</div>
</div>

<div id="changePass">
<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>New Password:</div>
	<div class="ui-block-b"><input type="text" name="newpass" id="newpassID1" value="" /></div>
	</div>
<div class="ui-grid-a">
	<div class="ui-block-a"><p></p>Confirm Password:</div>
	<div class="ui-block-b"><input type="text" name="newpass2" id="newpassID2" value="" /></div>
	</div>
</div>

<p></p>
		<p><a href="/Home/Index" data-theme="b" data-rel="back" data-role="button" data-inline="true" data-icon="back" onclick="showmap()">Close</a></p>	
	</div><!-- /content -->


</asp:Content>
