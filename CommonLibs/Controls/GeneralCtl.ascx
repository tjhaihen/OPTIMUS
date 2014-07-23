<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GeneralCtl.ascx.vb" 
    Inherits="CommonLibs.GeneralCtl" %>

<script src='<%= ResolveUrl("~/Libs/Scripts/jquery/jquery-1.4.3.js")%>' type='text/javascript'></script>
<script src='<%= ResolveUrl("~/Libs/Scripts/jquery/jquery-1.7.min.js")%>' type='text/javascript'></script>
<script type="text/javascript">
    //#region Right Panel
    $(function () {
        var isRightContentExists = false;
        if ($('#divRightPanelTasksContent').length) {
            //if ($('#divListRightPanel .containerRightPanelContent.tasks').children().length > 0) {
            isRightContentExists = true;
            $('.divOpenRightPanelContent[contentid=tasks]').show();
            $('#divListRightPanel .containerRightPanelContent.tasks').append($('#divRightPanelTasksContent'));
        }
        if ($('#divRightPanelInformationContent').length) {
            //if ($('#divListRightPanel .containerRightPanelContent.information').children().length > 0) {
            isRightContentExists = true;
            $('.divOpenRightPanelContent[contentid=information]').show();
            $('#divListRightPanel .containerRightPanelContent.information').append($('#divRightPanelInformationContent'));
        }
        if ($('#divRightPanelPrintContent').length) {
            //if ($('#divListRightPanel .rightPanelPrintContent').children().length > 0) {
            isRightContentExists = true;
            $('.divOpenRightPanelContent[contentid=print]').show();
            $('#divListRightPanel .containerRightPanelContent.print').append($('#divRightPanelPrintContent'));
        }

        if (isRightContentExists) {
            $('#containerRightPanel').show();
            var width = $('#divListRightPanel').width() + 12;
            $('#containerRightPanel').css('right', -width + "px");
            $('#containerRightPanel').attr('hideRight', -width + "px");
            var isOpenQuickMenu = false;
            $('.divRightPanelBackground').click(function () {
                if (!isOpenQuickMenu) {
                    isOpenQuickMenu = true;
                    $('#tdOpenRightPanel').addClass('open');
                    $('#containerRightPanel').animate({ "right": "0px" }, 200);
                }

                $('#divListRightPanel .containerRightPanelContent').hide();

                $('.divRightPanelBackgroundSelected').removeClass('divRightPanelBackgroundSelected');
                $('.divRightPanelBackgroundTopSelected').removeClass('divRightPanelBackgroundTopSelected');
                $('.divRightPanelBackgroundBottomSelected').removeClass('divRightPanelBackgroundBottomSelected');

                $td = $(this).parent();
                $td.children().each(function () {
                    var className = $(this).attr('class') + 'Selected';
                    $(this).addClass(className);
                });

                $('#headerRightPanelTitle').html($(this).find('.textRightPanel').html());
                $('.containerRightPanelContent.' + $td.parent().attr('contentid')).show();
            });
            $('#imgCloseRightPanel').click(function () {
                if (isOpenQuickMenu) {
                    isOpenQuickMenu = false;
                    $('#tdOpenRightPanel').removeClass('open');
                    $('#containerRightPanel').animate({ "right": $('#containerRightPanel').attr('hideRight') }, 200);
                    $('.divRightPanelBackgroundSelected').removeClass('divRightPanelBackgroundSelected');
                    $('.divRightPanelBackgroundTopSelected').removeClass('divRightPanelBackgroundTopSelected');
                    $('.divRightPanelBackgroundBottomSelected').removeClass('divRightPanelBackgroundBottomSelected');
                }
            });
            $('#btnRightPanelPrint').hover(function () {
                $('#btnRightPanelPrint').css('background-color', '#FFD300');
                $('#btnRightPanelPrint').css('cursor', 'pointer');
                                            },
                                            function () {
                $('#btnRightPanelPrint').css('background-color', 'transparent'); 
            });

        }
    });
    //#endregion
</script>
<style type="text/css">
    #containerRightPanel                            { font-size: 0.9em; }
    .divOpenRightPanelContent                       { max-height: 105px; display: none; }
    #tdOpenRightPanel                               { opacity: 0.6; }
    #tdOpenRightPanel.open                          { opacity: 1; }
    .textRightPanel                                 { position: absolute; right: -22px; top: 33px; text-align: center; width: 70px; color: #FFFFFF; -webkit-transform: rotate(-90deg); -moz-transform: rotate(-90deg); filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3); }
    .divRightPanelBackground                        { position:relative; cursor: pointer; background-image:url('<%=ResolveUrl("~/Libs/Images/Slide/tab_mrotate.png")%>');height:70px;width:30px;margin: 0px auto;color:White; padding-top:10px; }
    .divRightPanelBackgroundTop                     { cursor: pointer; background-image:url('<%=ResolveUrl("~/Libs/Images/Slide/tab_t.png")%>');background-position:center bottom;background-repeat:no-repeat;height: 13px; width: 30px; }
    .divRightPanelBackgroundBottom                  { cursor: pointer; background-image:url('<%=ResolveUrl("~/Libs/Images/Slide/tab_btm.png")%>'); background-position:center top;background-repeat:no-repeat;height: 13px; width: 30px; }
    .divRightPanelBackground:hover .textRightPanel  { text-decoration:underline; }
    
    .divRightPanelBackgroundSelected               { background-image:url('<%=ResolveUrl("~/Libs/Images/Slide/tab_mrotate_sel.png")%>'); }
    .divRightPanelBackgroundTopSelected            { background-image:url('<%=ResolveUrl("~/Libs/Images/Slide/tab_t_sel.png")%>'); }
    .divRightPanelBackgroundBottomSelected         { background-image:url('<%=ResolveUrl("~/Libs/Images/Slide/tab_btm_sel.png")%>'); }
    .divRightPanelBackgroundSelected .textRightPanel { color: #000; }
    
    .containerRightPanelContent                     { display: none; }
    #divListRightPanel .rightPanelContent           { width: 100%; padding: 10px 2px; }
    #divListRightPanel .rightPanelContent div       { margin-right:20px; }
    #divListRightPanel .rightPanelContent div.qmtitle { font-size:1.2em !important; }
    #divListRightPanel .rightPanelContent div.qmdescription { font-size:1em; }
    #divListRightPanel .rightPanelContent label     { color: #FFF; }
    #divListRightPanel .rightPanelContent input     { border: 0px; text-decoration: none; padding: 4px 10px; float: right; width: 50px; }
    #headerRightPanel                               { border-bottom: 1px solid #FFF; padding-bottom: 5px; }
    #imgCloseRightPanel                             { cursor: pointer; }
    #headerRightPanelTitle                          { float: right; padding: 0 5px 0 0; font-size: 1.6em; }
    #imgRightPanelPrint                             { cursor: pointer; }
    
    #divListRightPanel                                      { color: #FFF; background-color: #383839; }
    #divListRightPanel .rightPanelContent                   { border-bottom: 1px solid #FFF; }
    #divListRightPanel .rightPanelContent a                 { color: #FFF; background-color: #2585F3; }
    #divListRightPanel .rightPanelContent div.qmtitle       { color: #FFF !important; }
    #divListRightPanel .rightPanelContent div.qmdescription { color: #AAA; }

    .printToolbar                                   { background-color:#999999;width:100% }
    .btnRightPanelPrint:hover                       { background-color:#FFD300; cursor:pointer  }             
    .rdbCetakan                                     {   color : #FFF; }
    
</style>
<!--[if IE]>
<style type="text/css">
    .divRightPanelBackground                        { filter: alpha(opacity = 60); }
    .textRightPanel                                 { right: 5px; top: 0px;  }
    #tdOpenRightPanel                               { filter: alpha(opacity = 60);-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=60)";}
    #tdOpenRightPanel.open                          { filter: alpha(opacity = 100);-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)"; }
    #tdOpenRightPanel.open .divRightPanelBackground { filter: alpha(opacity = 100);-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)"; }
</style>
<![endif]-->

<div id="containerRightPanel" style="display:none;position:absolute;right:0px;top:156px;z-index:20000">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="vertical-align:top;padding-top:50px;" id="tdOpenRightPanel">
                <table cellpadding="0" cellspacing="0">
                    <tr class="divOpenRightPanelContent" contentid="tasks">
                        <td>
                            <div class="divRightPanelBackgroundTop">&nbsp;</div>
                            <div class="divRightPanelBackground">
                                <div class="textRightPanel">Tasks</div>
                            </div>
                            <div class="divRightPanelBackgroundBottom" />
                        </td>
                    </tr>
                    <tr class="divOpenRightPanelContent" contentid="information">
                        <td>
                            <div class="divRightPanelBackgroundTop">&nbsp;</div>
                            <div class="divRightPanelBackground">
                                <div class="textRightPanel">Information</div>
                            </div>
                            <div class="divRightPanelBackgroundBottom" />
                        </td>
                    </tr>
                    <tr class="divOpenRightPanelContent" contentid="print">
                        <td>
                            <div class="divRightPanelBackgroundTop">&nbsp;</div>
                            <div class="divRightPanelBackground">
                                <div class="textRightPanel">Print</div>
                            </div>
                            <div class="divRightPanelBackgroundBottom" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align:top;">
                <div id="divListRightPanel" style="width:350px;border:1px solid #AAA;height:450px;padding:5px;">
                    <div id="headerRightPanel">
                        <div id="headerRightPanelTitle">Tasks</div>
                        <img id="imgCloseRightPanel" src='<%=ResolveUrl("~/Libs/Images/Icon/right.png")%>' alt="C" title="Close" />
                    </div>
                    <div class="containerRightPanelContent tasks">
                        
                    </div>
                    <div class="containerRightPanelContent information">
                         
                    </div>
                    <div class="containerRightPanelContent print" style="z-index:20000;">

                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
