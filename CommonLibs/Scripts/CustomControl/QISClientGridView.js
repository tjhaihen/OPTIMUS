function RavenClientGridView() {
    var _self = this;
    this.clientID = '';
    this.init = function (clientID) {
        _self.clientID = clientID;
    }
    this.PerformCallback = function (param) {
        param = param == undefined ? '' : param;
        $('#' + _self.clientID + "_updPnlGridView_hdnCallbackParam").val('performcallback|' + param);
        eval(_self.clientID + "_updPnlGridView.PerformCallback()");
    }
    this.GetSelectedRowKeyValue = function () {
        return $('#' + _self.clientID + "_updPnlGridView_hdnSelected").val();
    }
}

function RavenClientGridViewHelper() {
    var _self = this;
    this.clientID = '';

    this.clientInstanceName = '';
    this.onRowClick = '';
    this.onRowDblClick = '';
    this.setParam = function (clientInstanceName, onRowClick, onRowDblClick) {
        _self.clientInstanceName = clientInstanceName;
        _self.onRowClick = onRowClick;
        _self.onRowDblClick = onRowDblClick;
    }
    this.init = function (clientID) {
        _self.clientID = clientID;
        _self.initPagination();
        _self.initializeGridView(true);

        var pagingHeight = $('#' + _self.clientID + '_divContainer .containerPaging').height();
        $newContainerDiv = $('<div></div>');
        $newContainerDiv.attr('id', _self.clientID + '_divNewContainer');
        $newContainerDiv.attr('style', $('#' + _self.clientID + '_divContainer').attr('style'));
        //$newContainerDiv.width($('#' + _self.clientID + '_divContainer').width());
        $newContainerDiv.height(pagingHeight);
        $newContainerDiv.insertAfter($('#' + _self.clientID + '_divContainer').parent().parent());

        $tempDivPaging = $("#" + _self.clientID + "_Paging").parent().parent().parent().parent().parent().parent();
        $newContainerDiv.append($tempDivPaging);
        $tempDivPaging.attr('id', _self.clientID + "_newContainerPaging");

        _self.setBlanketHeight();
    }

    this.setBlanketHeight = function () {
        var height = $("#" + _self.clientID + ' .grdBlanket').height();
        height += $('#' + _self.clientID + '_divNewContainer').height();
        $('.grdBlanket').height(height);
    }

    this.initPagination = function () {
        var pageCount = $('#' + _self.clientID + "_updPnlGridView_hdnPageCount").val();
        if (pageCount != '0') {
            $('#' + _self.clientID + '_divContainer .divGridViewScroller').show();
            $('#' + _self.clientID + '_divContainer .divGrdEmpty').hide();
            $('#' + _self.clientID + '_newContainerPaging').show();
            $('#' + _self.clientID + '_divContainer .containerPaging').show();
            setTimeout(function () {
                $("#" + _self.clientID + "_Paging").paginate({
                    count: $('#' + _self.clientID + "_updPnlGridView_hdnPageCount").val(),
                    start: $('#' + _self.clientID + "_updPnlGridView_hdnPageIndex").val(),
                    display: 12,
                    border: false,
                    text_color: '#3E4846',
                    background_color: 'transparent',
                    text_hover_color: '#444444',
                    background_hover_color: '#F7E7A6',
                    images: false,
                    mouse: 'press',
                    onChange: function () {
                        var getPage = $('.jPag-current').html();
                        $('#' + _self.clientID + "_updPnlGridView_hdnPageIndex").val(getPage);
                        $('#' + _self.clientID + "_updPnlGridView_hdnCallbackParam").val('pagechanged|' + getPage);
                        eval(_self.clientID + "_updPnlGridView.PerformCallback()");
                    }
                });
            }, 0);
        }
        else {
            //$("#" + _self.clientID + "_Paging").empty();
            $('#' + _self.clientID + '_divContainer .divGridViewScroller').hide();
            $('#' + _self.clientID + '_newContainerPaging').hide();
            $('#' + _self.clientID + '_divContainer .divGrdEmpty').show();
            $('#' + _self.clientID + '_divContainer .containerPaging').hide();
        }
    }
    this.initializeGridView = function (isInit) {
        //$('.divContainer').find('input[type=hidden]').each(function () {
        //    alert($(this).attr('name'));
        //});


        $('#' + _self.clientID + "_updPnlGridView_hdnSelected").val('');
        $('#' + _self.clientID + "_updPnlGridView_grdView" + ' tr').click(function () {
            _self.setFocusRow($(this), false);
        });


        $('#' + _self.clientID + "_updPnlGridView_grdView" + ' tr').dblclick(function () {
            //window[_self.clientID + "OnDblRowClick"]();
            if (_self.onRowDblClick != '')
                eval("Methods.ExecuteFunction(" + _self.clientID + "RowDblClickVar, " + _self.clientInstanceName + ");");
        });

        var selectedRowIdx = $('#' + _self.clientID + "_updPnlGridView_hdnFocusedRowIndex").val();
        _self.setFocusRow($('#' + _self.clientID + "_updPnlGridView_grdView" + ' tr:eq(' + selectedRowIdx + ')'), isInit);


        var rowCount = $('#' + _self.clientID + "_updPnlGridView_hdnRowCount").val();
        var pageCount = $('#' + _self.clientID + "_updPnlGridView_hdnPageCount").val();
        var pageIndex = $('#' + _self.clientID + "_updPnlGridView_hdnPageIndex").val();
        $('#' + _self.clientID + "_PageInformation").html("Page " + pageIndex + " of " + pageCount + " (" + rowCount + " items)");

        var height = $('#' + _self.clientID + '_divContainer').height();
        height -= $('#' + _self.clientID + '_updPnlGridView_grdViewHeader').height();
        $('#' + _self.clientID + "_updPnlGridView_divGridViewScroller").height(height);
    }
    this.setFocusRow = function ($row, isInit) {
        $row.parent().children().attr('class', '');
        $row.attr('class', 'selected');

        var idValue = $row.find('.hdnValue').html();
        $('#' + _self.clientID + "_updPnlGridView_hdnSelected").val(idValue);

        $('#' + _self.clientID + "_updPnlGridView_hdnFocusedRowIndex").val($('#' + _self.clientID + "_updPnlGridView_grdView" + ' tr').index($row));

        if (!isInit) {
            if (_self.onRowClick != '')
                eval("Methods.ExecuteFunction(" + _self.clientID + "RowClickVar, " + _self.clientInstanceName + ");");
            
            //window[_self.clientID + "OnRowClick"]();
        }
    }
    this.onBeginCallback = function () {
        $('#' + _self.clientID + '_divContainer .grdBlanket').show();
        $('#' + _self.clientID + '_divContainer .imgLoadingRpt').show();
    }
    this.onEndCallback = function () {
        var type = $('#' + _self.clientID + '_updPnlGridView_hdnCallbackParam').val().split('|')[0];
        $('#' + _self.clientID + '_updPnlGridView_hdnCallbackParam').val('');

        $('#' + _self.clientID + '_containerPaging').remove();
        $('#' + _self.clientID + ' .grdBlanket').hide();
        $('#' + _self.clientID + '_divContainer .imgLoadingRpt').hide();

        if (type != '')
            $('#' + _self.clientID + "_updPnlGridView_hdnFocusedRowIndex").val('0');

        _self.initializeGridView(false);
        //_self.setBlanketHeight();
        if (type == 'performcallback')
            _self.initPagination();

    }
}