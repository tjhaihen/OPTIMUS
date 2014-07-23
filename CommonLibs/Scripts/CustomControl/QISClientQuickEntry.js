function RavenClientQuickEntry() {
    var _self = this;
    this.clientID = '';
    this.columns = [];
    this.init = function (clientID, columns) {
        _self.clientID = clientID;
        _self.columns = columns;
    }
    this.GetValue = function () {
        var value = $('#' + _self.clientID + '_divAutoComplete .hdnAutoCompleteValue').val();
        var paramValue = value.split(';');

        var textValue = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val();
        var paramTextValue = textValue.split(";");
        var numSeparator = paramTextValue.length;
        for (var i = 0; i < numSeparator; ++i) {
            if (i < _self.columns.length) {
                if (_self.columns[i].methodName == null || _self.columns[i].methodName == '') {
                    paramValue[i] = paramTextValue[i];
                }
            }
        }
        return paramValue.join(';');
    }
    this.GetText = function () {
        return $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val();
    }
    this.SetText = function (value) {
        $('#' + _self.clientID + '_divAutoComplete .hdnAutoCompleteValue').val(value);
        $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val(value);
        _self.setTextBold();
    }
    this.SetFocus = function () {
        $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').focus();
    }
    this.setTextBold = function () {
        var textValue = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val();
        textValue = textValue.substring(0, _self.doGetCaretPosition());
        var numSeparator = (textValue.split(";").length - 1);

        var intellisenseText = '';
        var intellisenseDescription = '';
        for (var i = 0; i < _self.columns.length; ++i) {
            if (intellisenseText != '')
                intellisenseText += ';';

            if (i == numSeparator) {
                intellisenseText += '<b>' + _self.columns[i].text + '</b>';
                if (_self.columns[i].description != '')
                    intellisenseDescription = '<b>' + _self.columns[i].text + '</b> : ' + _self.columns[i].description;
            }
            else
                intellisenseText += _self.columns[i].text;
        }
        $('#' + _self.clientID + '_divAutoComplete .autoCompleteIntellisenseContentText').html(intellisenseText);
        $('#' + _self.clientID + '_divAutoComplete .intellisenseDescription').html(intellisenseDescription);
    }
    this.doGetCaretPosition = function () {
        var oField = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete')[0];
        var iCaretPos = 0;
        // IE Support
        if (document.selection) {
            oField.focus();
            var oSel = document.selection.createRange();
            oSel.moveStart('character', -oField.value.length);
            iCaretPos = oSel.text.length;
        }
        // Firefox support
        else if (oField.selectionStart || oField.selectionStart == '0')
            iCaretPos = oField.selectionStart;
        // Return results
        return (iCaretPos);
    }
}

function RavenClientQuickEntryHelper() {
    var _self = this;
    this.timer = null;
    this.idxSelectedRow = 0;
    this.numRows = 0;
    this.clientID = '';
    this.columns = [];
    this.onSearchClick = '';
    this.clientInstance = '';
    this.isHoverTable = '';
    this.init = function (clientID, columns) {
        _self.columns = columns;
        _self.clientID = clientID;
        _self.initializeControl();
        _self.setTextBold();
    }
    this.setParam = function (clientInstance, onSearchClick) {
        _self.onSearchClick = onSearchClick;
        _self.clientInstance = clientInstance;
    }
    this.setTextBold = function () {
        var textValue = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val();
        textValue = textValue.substring(0, _self.doGetCaretPosition());
        var numSeparator = (textValue.split(";").length - 1);

        var intellisenseText = '';
        var intellisenseDescription = '';
        for (var i = 0; i < _self.columns.length; ++i) {
            if (intellisenseText != '')
                intellisenseText += ';';

            if (i == numSeparator) {
                intellisenseText += '<b>' + _self.columns[i].text + '</b>';
                if (_self.columns[i].description != '')
                    intellisenseDescription = '<b>' + _self.columns[i].text + '</b> : ' + _self.columns[i].description;
            }
            else
                intellisenseText += _self.columns[i].text;
        }
        $('#' + _self.clientID + '_divAutoComplete .autoCompleteIntellisenseContentText').html(intellisenseText);
        $('#' + _self.clientID + '_divAutoComplete .intellisenseDescription').html(intellisenseDescription);
    }
    this.initializeControl = function () {
        $("#" + _self.clientID + "_divAutoComplete .txtAutoComplete").keypress(function (e) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 40 || code == 38) {
                e.preventDefault();
            }
        });

        $("#" + _self.clientID + "_divAutoComplete .txtAutoComplete").keydown(function (e) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 40) { //down
                if (_self.idxSelectedRow < _self.numRows)
                    _self.changeIdxSelectedRow(1);
            }
            else if (code == 38) { //up
                if (_self.idxSelectedRow > 1)
                    _self.changeIdxSelectedRow(-1);
            }
            else if (code == 13) { //enter
                if ($('#' + _self.clientID + '_divAutoComplete .autoCompleteBox').is(':visible')) {
                    if (_self.idxSelectedRow > 0) {
                        $row = $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent tr[class=selected]');
                        _self.selectRow($row[0]);
                        $('#' + _self.clientID + '_divAutoComplete .autoCompleteBox').fadeOut();
                        _self.setTextBold();
                    }
                }
                else {
                    _self.onSearchClick(_self.clientInstance);
                }
            }
            else if (code == 59 || code == 9) { // 59 => ;     9 => Tab
                if ($('#' + _self.clientID + '_divAutoComplete .autoCompleteBox').is(':visible')) {
                    e.preventDefault();
                    if (_self.idxSelectedRow > 0) {
                        $row = $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent tr[class=selected]');
                        _self.selectRow($row[0]);
                        $('#' + _self.clientID + '_divAutoComplete .autoCompleteBox').fadeOut();
                        _self.setTextBold();
                    }
                }
            }
            else if (code == 37 || code == 39) { // left right
                _self.setTextBold();
            }
        });

        $("#" + _self.clientID + "_divAutoComplete .txtAutoComplete").keyup(function (e) {
            if (_self.timer) {
                clearTimeout(_self.timer);
            }
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 9 || (code === 9 && e.shiftKey)) {
            }
            else {
                if (code == 40) { //down
                }
                else if (code == 38) { //up
                }
                else if (code == 13) { //enter
                }
                else if (code == 37 || code == 39) { // left right
                }
                else {
                    _self.setTextBold();
                    if ($(this).val() != '')
                        _self.timer = setTimeout(_self.getAutoComplete, 200);
                    else
                        $('#' + _self.clientID + '_divAutoComplete .autoCompleteBox').fadeOut();
                }
            }
        });

        $("#" + _self.clientID + "_divAutoComplete .txtAutoComplete").focus(function () {
            $("#" + _self.clientID + "_divAutoComplete .autoCompleteIntellisenseBox").fadeIn();
            _self.setTextBold();
        });

        $("#" + _self.clientID + "_divAutoComplete .txtAutoComplete").blur(function () {
            $("#" + _self.clientID + "_divAutoComplete .autoCompleteIntellisenseBox").fadeOut();
            $("#" + _self.clientID + "_divAutoComplete .autoCompleteBox").fadeOut();

            //if (!_self.isHoverTable) {
            //    _self.onLostFocus(_self.clientInstance);
            //}
        });

        $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent').find("tr:gt(0)").live("click", function () {
            _self.selectRow(this);
            $("#" + _self.clientID + "_divAutoComplete .txtAutoComplete").focus();
        });

        $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent').hover(function () {
            _self.isHoverTable = true;
        }, function () {
            _self.isHoverTable = false;
        });
    }

    this.changeIdxSelectedRow = function (val) {
        _self.idxSelectedRow += val;

        $("#" + _self.clientID + "_divAutoComplete .tblAutoCompleteContent").find("tr:gt(0)").attr('class', '');

        $selectedRow = $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent tr:eq(' + _self.idxSelectedRow + ')');
        var position = $selectedRow.position();
        $selectedRow.attr('class', 'selected');

        var objDiv = $("#" + _self.clientID + "_divAutoComplete .autoCompleteContent")[0];
        var newScrollTop = objDiv.scrollTop;
        if ($("#" + _self.clientID + "_divAutoComplete .autoCompleteContent").height() <= position.top) {
            var diff = position.top - $("#" + _self.clientID + "_divAutoComplete .autoCompleteContent").height();
            newScrollTop += $selectedRow.height() + diff;
        }
        else if (position.top < 1)
            newScrollTop -= $selectedRow.height() - position.top;
        objDiv.scrollTop = newScrollTop;
    }

    this.getAutoComplete = function () {
        var textValue = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val();
        var paramTextValue = textValue.split(';');
        textValue = textValue.substring(0, _self.doGetCaretPosition());
        var numSeparator = (textValue.split(";").length - 1);

        if (_self.columns[numSeparator].methodName != null && _self.columns[numSeparator].methodName != '') {
            if (paramTextValue[numSeparator] != '') {
                $("#" + _self.clientID + "_divAutoComplete .imgLoadingAutoComplete").show();
                var filterExpression = _self.columns[numSeparator].filterExpression;
                if (filterExpression != '')
                    filterExpression += ' AND ';
                if (_self.columns[numSeparator].column != null) {
                    var col = _self.columns[numSeparator].column;
                    var filter = '';
                    for (var i = 0; i < col.length; ++i) {
                        if (filter != '')
                            filter += ' OR ';
                        filter += col[i].name + " LIKE '%" + paramTextValue[numSeparator] + "%'";
                    }
                    filterExpression += filter;
                }
                else
                    filterExpression += _self.columns[numSeparator].fieldName + " LIKE '%" + paramTextValue[numSeparator] + "%'";
                _self.getListObject(_self.columns[numSeparator].methodName, filterExpression);
            }
            else {
                $('#' + _self.clientID + '_divAutoComplete .autoCompleteBox').fadeOut();
            }
        }
    }

    this.getListObject = function (methodName, filterExpression) {
        $.ajax({
            // have to use synchronous here, else returns before data is fetched
            async: false,
            type: 'POST',
            url: ResolveUrl('~/Service/MethodService.asmx/GetLimitListObject'),
            contentType: 'application/json; charset=utf-8',
            data: '{ "methodName" : "' + methodName + '", "filterExpression" : "' + filterExpression + '", "pageCount" : "10" }',
            dataType: 'json',
            error: function (msg) {
                alert(msg.responseText);
            },
            success: function (msg) {
                _self.onLoadObject(msg.d);
            }
        });     //end ajax
    };

    this.onLoadObject = function (result) {
        var textValue = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val();
        textValue = textValue.substring(0, _self.doGetCaretPosition());
        var numSeparator = textValue.split(";").length;

        $('#' + _self.clientID + '_divAutoComplete .imgLoadingAutoComplete').hide();
        $('#' + _self.clientID + '_divAutoComplete .autoCompleteBox').fadeIn();

        $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent tr').remove();
        $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent').html($("#" + _self.clientID + "_divAutoComplete .headerAutoComplete" + numSeparator).html());

        $("#" + _self.clientID + "_divAutoComplete .tmplAutoComplete" + numSeparator).tmpl(result).appendTo('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent');
        _self.numRows = result.length;
        _self.idxSelectedRow = 1;

        $selectedRow = $('#' + _self.clientID + '_divAutoComplete .tblAutoCompleteContent tr:eq(' + _self.idxSelectedRow + ')');
        $selectedRow.attr('class', 'selected');

        var objDiv = $("#" + _self.clientID + "_divAutoComplete .autoCompleteContent")[0];
        objDiv.scrollTop = 0;
    }

    this.selectRow = function (row) {
        var entity = $.tmplItem(row).data;
        var textValue = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val();
        var paramTextValue = textValue.split(';');
        textValue = textValue.substring(0, _self.doGetCaretPosition());
        var numSeparator = (textValue.split(";").length) - 1;

        paramTextValue[numSeparator] = entity[_self.columns[numSeparator].fieldName];
        if (numSeparator == paramTextValue.length - 1) {
            paramTextValue[numSeparator + 1] = '';
        }
        $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete').val(paramTextValue.join(';'));

        var value = $('#' + _self.clientID + '_divAutoComplete .hdnAutoCompleteValue').val();
        var paramValue = value.split(';');
        paramValue[numSeparator] = entity[_self.columns[numSeparator].valueField];
        $('#' + _self.clientID + '_divAutoComplete .hdnAutoCompleteValue').val(paramValue.join(';'));
        //alert($('#' + _self.clientID + '_divAutoComplete .hdnAutoCompleteValue').val());
    }

    this.doGetCaretPosition = function () {
        var oField = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete')[0];
        var iCaretPos = 0;
        // IE Support
        if (document.selection) {
            oField.focus();
            var oSel = document.selection.createRange();
            oSel.moveStart('character', -oField.value.length);
            iCaretPos = oSel.text.length;
        }
        // Firefox support
        else if (oField.selectionStart || oField.selectionStart == '0')
            iCaretPos = oField.selectionStart;
        // Return results
        return (iCaretPos);
    }
    this.doSetCaretPosition = function (iCaretPos) {
        var oField = $('#' + _self.clientID + '_divAutoComplete .txtAutoComplete')[0];
        // IE Support
        if (document.selection) {
            oField.focus();
            var oSel = document.selection.createRange();
            oSel.moveStart('character', -oField.value.length);
            oSel.moveStart('character', iCaretPos);
            oSel.moveEnd('character', 0);
            oSel.select();
        }

        // Firefox support
        else if (oField.selectionStart || oField.selectionStart == '0') {
            oField.selectionStart = iCaretPos;
            oField.selectionEnd = iCaretPos;
            oField.focus();
        }
    }
}