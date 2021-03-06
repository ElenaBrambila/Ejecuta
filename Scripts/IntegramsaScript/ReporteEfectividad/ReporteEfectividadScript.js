


//Global vars
var globalMainHeadings = "";
var globalSubHeadings = "";
var globalValues = "";
var globalUniquePromotorList = "";
var AryPromotor, AryTA, AryCOB, AryFP, AryDP;
var AryRows = [];
var newAry = [];
var CountRow = 0;
var CountDays = 0;
var daysToCount = 0;
var modelResponse = null;
var loader = document.getElementById('loader'),
    load = document.getElementById('loading'),
    newTime = 0;
var multi = 0;
var porcentage = 0;
var totalCount = 0;
var myTime = 0;



var tableToExcel = (function () {
            // Define your style class template.
            var style = "<style>.firstChild { display: none;mso-outline-level:1} .groupHeading {font-weight: bold;mso-outline-parent:collapsed} .headingYellow { background-color: RGB(245,230,145);} .headingGreen { background-color: RGB(142,211,151);} .bgRed{ background-color: RGB(237,28,36);} </style>";
            var uri = 'data:application/vnd.ms-excel;base64,'
                , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]-->' + style + '</head><body><table>{table}</table></body></html>'
                , base64 = function (s) {
                    return window.btoa(unescape(encodeURIComponent(s)))
                }
                , format = function (s, c) {
                    return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; })
                }
                , formatSpanish = function (s) {
                    return s.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
                }
            return function (table, name) {
                if (!table.nodeType) table = document.getElementById(table)
                var ctx = { worksheet: 'Reporte Efectividad', table: table.innerHTML }
                // window.location.href = uri + base64(format(template, ctx))
                var link = document.createElement("a");
                link.download = "ReporteEfectividad.xls";
                console.log(format(template, ctx));
                console.log(formatSpanish(format(template, ctx)));
                link.href = uri + base64(formatSpanish(format(template, ctx)));
                link.click();
            }
        })()


function getReporteEfectividad(url, myModel) {

    HttpClientAjaxAsync("POST", url, myModel)
        .then((data) => {
            doEachItem(data);
        })
        .catch((error) => {
            console.log(error)
        })
}


function getDeterminante(url, myModel) {

    HttpClientAjaxAsync("POST", url, myModel)
        .then((data) => {
            doEachItem(data);
        })
        .catch((error) => {
            console.log(error)
        })
}

function doEachItem(data) {
    var countItem = data.length

    if (countItem > 0) {
        $('#buttons').show();
        data.forEach(function (item, i) {

            if (i <= countItem) {
                loading(countItem, i)
                fxnGenerateTemplate(item.cliente, item.codigoRuta, item.coordinador, item.promotor, item.det, item.tienda, item.info, item.StartDate, item.EndDate, item.uniquePromotorList)
            } else {
                load.style.opacity = '0';
                $(".loader-center").css({ 'position': 'unset' });
                return;
            }

        });
    } else {
        $('#buttons').hide();
        load.style.opacity = '0';
        $(".loader-center").css({ 'position': 'unset' });
        $('#divTbl').text("La consulta no produjo ningun resultado.");
    }

}



function loading(countTotal, index) {
    'use strict';

    if (index == 0) {
        multi = 100 / countTotal;
        porcentage = Math.ceil(multi);
        totalCount = countTotal * multi;

    }
    myTime = myTime + porcentage

    if (myTime >= totalCount) {

        //console.log("Cerrar  " + " myTime = " + myTime + " Total = " + totalCount);
        //load.style.transition = '1s all';
        load.style.opacity = '0';
        $(".loader-center").css({ 'position': 'unset' });

    }
    //else {
    //    //loader.textContent = myTime + "%";
    //   /* $('#loader').text(myTime + "%");*/
    //    console.log(" myTime = " + myTime + " Total = " + totalCount);
    //}
}

function float2int(value) {
    return value | 0;
}


/*
 *
*/
function fxnPrintGloabalData() {

    vTable = AryRows;
    var varglobal = [];
    var varglobal2 = [];
    var vMainHeader = "<th class='headingGreen' style='min-width:70px'>CLIENTE</th> <th class='headingGreen' style='min-width:70px'>RUTA</th> <th class='headingGreen' style='min-width:120px'>COORDINADOR</th> <th class='headingGreen' style='min-width:200px'>PROMOTOR</th> <th class='headingGreen' style='min-width:50px'>DET</th> <th class='headingGreen' style='min-width:250px'>TIENDA</th>";
    vSubHeader = "<th class='headingGreen' style='min-width:70px'></th><th class='headingGreen' style='min-width:70px'></th><th class='headingGreen' style='min-width:120px'></th><th class='headingGreen' style='min-width:200px'></th><th class='headingGreen' style='min-width:50px'></th><th class='headingGreen' style='min-width:250px'></th>";
    var sGroupRow = "";
    var sVals = "";

    var sValsWithGroup = "";
    var taTotal = 0, cobTotal = 0, fpTotal = 0, dpTotal = 0, countRowsForDPAverage = 0, acumulado = 0, dpAcumu = 0;

    var AryRowSum = [];

    var AryInfoSum = [];
    var isFirstRowForPromoterGroup = "Yes";
    var flagHeadingColorSwitch = "On";
    var listAcum = [];
    var listDP = [];
    for (var r = 1; r < AryRows.length; r++) {

        var rVals = [];
        rVals = AryRows[r]; // One row value come here - rVals
        var sPromoterName = rVals[3];
        var sNextPromoterName = [];

        if ((r + 1) < AryRows.length) {
            sNextPromoterName = AryRows[r + 1];
            sNextPromoterName = sNextPromoterName[3];
        }

        if ((r + 1) == AryRows.length) {
            sGroupRow = "<td colspan='5'> " + sPromoterName + " <td>";
        }
        if ((r + 1) < AryRows.length) {
            sGroupRow = "<td colspan='5'> " + sPromoterName + " <td>";
        }
        else { sNextPromoterName = ""; }
        if (sPromoterName == sNextPromoterName) {
            sGroupRow = "<td colspan='5'> " + sPromoterName + " <td>";
        }

        sVals += "<tr class='firstChild'><td style='min-width:70px'>" + rVals[0] + "</td> <td style='min-width:70px'>" + rVals[1] + "</td> <td style='min-width:120px'>" + rVals[2] + "</td> <td style='min-width:200px'>" + rVals[3] + "</td> <td style='min-width:50px'>" + rVals[4] + "</td> <td style='min-width:250px'>" + rVals[5] + "</td>";
        var countTa = 0;
        var AcumLis = [];
        for (var c = 6; c < rVals.length; c++) {

            var n = c - 6; // n for count columns for dates
            var AryInfo = [];
            AryInfo = rVals[c];

            // Printing info values
            var v2Print1 = parseInt(AryInfo[1]);
            var v2Print2 = parseInt(AryInfo[2]);
            var v2Print3 = parseInt(AryInfo[3]);
            var v2Print4 = parseInt(AryInfo[4]);
            var v2Print5 = parseInt(AryInfo[5]);
            if (v2Print1 == 0 || isNaN(v2Print1)) {
                v2Print1 = "-";
                v2Print2 = "-";
                v2Print3 = "-";
                v2Print4 = "-";
                v2Print5 = "-";
            }
            if (isNaN(v2Print1)) {
                v2Print1 = "-";
            }
            if (isNaN(v2Print2)) {
                v2Print2 = "-";
            }
            if (isNaN(v2Print3)) {
                v2Print3 = "-";
            }
            if (isNaN(v2Print4)) {
                v2Print4 = "-";
            }
            if (v2Print1 != 0) {
                sVals += "<td style='text-align:center;min-width:34px'>" + v2Print1 + "</td>";

                if (v2Print1 != "-") {
                    countTa++;
                }
            } else {
                sVals += "<td style='text-align:center;min-width:34px'>" + v2Print1 + "</td>";
            }
            if (v2Print2 == 0) {
                sVals += "<td class='bgRed' style='text-align:center;min-width:45px'>" + v2Print2 + "</td>";
            } else {
                sVals += "<td style='text-align:center;min-width:45px'>" + v2Print2 + "</td>";
            }
            if (v2Print3 == 0) {
                // sVals += "<td class='bgRed' style='text-align:center;min-width:34px'>" + v2Print3 + "</td>";
                sVals += "<td style='text-align:center;min-width:45px'>-</td>";
            } else {
                sVals += "<td style='text-align:center;min-width:34px'>" + v2Print3 + "</td>";
            }
            if (v2Print4 == 0) {
                sVals += "<td class='bgRed' style='text-align:center;min-width:45px'>" + v2Print4 + "%</td>";
            } else if (v2Print4 == "-") {
                sVals += "<td style='text-align:center;min-width:45px'>-</td>";
            } else {
                sVals += "<td style='text-align:center;min-width:45px'>" + v2Print4 + "%</td>";
            }

            var AryTempSum = [];
            if (isFirstRowForPromoterGroup != "Yes") //if not first row, get old values to calculate
            {
                var tempAryInfoSum = AryRowSum[0];
                var tempAryRowSum = tempAryInfoSum[n];

                taTotal = tempAryRowSum[0];
                cobTotal = tempAryRowSum[1];
                fpTotal = tempAryRowSum[2];
                dpTotal = tempAryRowSum[3];
                acumulado = tempAryRowSum[4];
            }

            var v1 = parseInt(AryInfo[1]);
            if (isNaN(v1)) { v1 = 0; }
            var v2 = parseInt(AryInfo[2]);
            if (isNaN(v2)) { v2 = 0; }
            var v3 = parseInt(AryInfo[3]);
            if (isNaN(v3)) { v3 = 0; }
            var v4 = parseInt(AryInfo[4]);
            if (isNaN(v4)) { v4 = 0; }
            var v5 = parseInt(AryInfo[5]);
            if (isNaN(v5)) { v5 = 0; }


            taTotal += v1;
            cobTotal += v2;
            fpTotal += v3;
            dpTotal += v4;
            acumulado += v5;
            AcumLis.push(v4);


            if (taTotal == 0) {
                taTotal == "-";
            }

            AryTempSum[0] = taTotal;
            AryTempSum[1] = cobTotal;
            AryTempSum[2] = fpTotal;
            AryTempSum[3] = dpTotal;
            AryTempSum[4] = acumulado;
            listDP.push(AryTempSum[3]);

            taTotal = 0;
            cobTotal = 0;
            fpTotal = 0;
            dpTotal = 0;
            acumulado = 0;
            let totalDps = 0;

            for (let i of AcumLis) totalDps += i;
            var dptotalcolumn = Math.round(parseInt(totalDps) / AcumLis.length);
            // print headers one time
            if (r == 1) {

                if (flagHeadingColorSwitch == "On") {
                    vMainHeader += "<th colspan='4' class='headingGreen' style='min-width:147px'>" + AryInfo[0] + "</th>"; // heading -  Day and Date
                    //  vSubHeader += "<th class='headingGreen' style='text-align:center;min-width: 34px;'> TA </th> <th class='headingGreen' style='text-align:center;min-width: 45px;'> COB </th> <th class='headingGreen' style='text-align:center;min-width: 34px;'> FP </th> <th class='headingGreen' style='text-align:center;min-width: 75px;'> DP - " + dptotalcolumn+"%</th>";
                    flagHeadingColorSwitch = "Off";
                }
                else {
                    vMainHeader += "<th colspan='4' class='headingYellow' style='min-width:147px'>" + AryInfo[0] + "</th>"; // heading -  Day and Date
                    //  vSubHeader += "<th class='headingYellow' style='text-align:center;min-width: 34px;'> TA </th> <th class='headingYellow' style='text-align:center;min-width: 45px;'> COB </th> <th class='headingYellow' style='text-align:center;min-width: 34px;'> FP </th> <th class='headingYellow' style='text-align:center;min-width: 75px;'> DP - " + dptotalcolumn +"%</th>";
                    flagHeadingColorSwitch = "On";
                }
            }


            AryInfoSum[n] = AryTempSum;
            AryRowSum[0] = AryInfoSum;

        }


        sVals += "</tr>";
        AryRowSum[0] = AryInfoSum;

        if (sPromoterName == sNextPromoterName) {
            isThisRowPromoterAndNextRowPromoterSame = "Yes";
            isFirstRowForPromoterGroup = "No";

        }
        else {
            var dpSu = [];
            var daysToDayAverage = [];
            var bandera = false;
            var dias = [];
            var dpList = [];
            for (var i = 0; i < AryRowSum.length; i++) {

                AryInfoSum = AryRowSum[i];

                for (var j = 0; j < AryInfoSum.length; j++) {
                    AryTempSum = AryInfoSum[j];

                    countRowsForDPAverage = parseInt(AryTempSum[0]);
                    if (countRowsForDPAverage == 0) {
                        var avrg = 0;
                        var acumulado = 0;
                        bandera = true;
                    } else {
                        var avrg = Math.round(parseInt(AryTempSum[3]) / countRowsForDPAverage);
                        var acumulado = (Math.round(parseInt(AryTempSum[3]) / countRowsForDPAverage)) / countTa;
                        dias.push(1);

                        dpList.push(AryTempSum[3]);

                    }
                    dpSu.push(avrg);
                    if (AryTempSum[0] == 0) {
                        daysToDayAverage.push('-');
                        sGroupRow += "<td style=\"text-align:center\">-</td>  <td style=\"text-align:center\">-</td>  <td style=\"text-align:center\">-</td>   <td style=\"text-align:center\">-</td>";
                    } else if (avrg == 0) {
                        daysToDayAverage.push(avrg);
                        sGroupRow += "<td style=\"text-align:center\">" + AryTempSum[0] + "</td>  <td style=\"text-align:center\">" + AryTempSum[1] + "</td>  <td style=\"text-align:center\">" + AryTempSum[2] + "</td>   <td style=\"text-align:center\" class=\"bgRed\">" + avrg + "%</td>";
                    } else {
                        daysToDayAverage.push(avrg);
                        sGroupRow += "<td style=\"text-align:center\">" + AryTempSum[0] + "</td>  <td style=\"text-align:center\">" + AryTempSum[1] + "</td>  <td style=\"text-align:center\">" + AryTempSum[2] + "</td>   <td style=\"text-align:center\">" + avrg + "%</td>";
                    }

                }

                varglobal.push(dpSu);
                varglobal2.push(daysToDayAverage);
            }

            let total = 0
            let totalDias = 0

            for (let i of dpSu) total += i;
            for (let i of dias) totalDias += i;

            var sumAcum = Math.round(total / totalDias);

            var transposed2 = transpose(varglobal2);

            listAcum.push(sumAcum);

            sValsWithGroup += "<tr class='groupHeading'>" + sGroupRow + " <th> " + sumAcum + "% </th> </tr><tbody class=\"collipsableContent\">" + sVals + "</tbody>";
            sVals = ""
            AryRowSum = [];
            AryInfoSum = [];
            AryTempSum = [];
            countRowsForDPAverage = 0;
            isThisRowPromoterAndNextRowPromoterSame = "No";
            isFirstRowForPromoterGroup = "Yes";
        }

    }

    var transposed2 = transpose(varglobal2);

    for (let i = 0; i < transposed2.length; i++) {
        var total1 = 0;
        var days = 0;
        for (let r of transposed2[i]) {
            if (typeof r == 'number') {
                total1 += r;
                days++;
            }
        }
        let dayAverage = Math.round(total1 / days);

        if (isNaN(dayAverage)) {
            dayAverage = '';
        }

        vSubHeader += "<th class='headingGreen' style='text-align:center;min-width: 34px;'> TA </th> <th class='headingGreen' style='text-align:center;min-width: 45px;'> COB </th> <th class='headingGreen' style='text-align:center;min-width: 34px;'> FP </th> <th class='headingGreen' style='text-align:center;min-width: 75px;'> DP - " + dayAverage + "%</th>";

    }
    let totalA = 0
    /*console.log(listAcum);*/
    for (let i of listAcum) totalA += i;

    var tot = Math.round(totalA / listAcum.length);

    vSubHeader += "<th style='color:black'><strong>" + tot + "%</strong></th>";

    var vTable = "<table id='tableInfo' class='table table-hover table-bordered' >  <tr class='mainHeading' id='mainHeading'> " + vMainHeader + " <th> ACUMULADO </th> </tr> <tr id='mainSubHeading'> " + vSubHeader + " <th> </th>  </tr> " + sValsWithGroup + " </table>";
    var vDivTable = this.document.getElementById("divTbl");

    vDivTable.innerHTML = vTable;
    /* this.document.getElementById("divKendo").innerHTML = "";*/
}

function transpose(matrix) {
    return matrix[0].map((col, i) => matrix.map(row => row[i]));
}

function add(accumulator, a) {
    return accumulator + a;
}

/*
 * Function to create template, enters once per row received from WS
*/
function fxnGenerateTemplate(cliente, codigoRuta, coordinador, promotor, det, tienda, info, StartDate, EndDate, uniquePromotorList) {
    CountRow = CountRow + 1;
    const weekday = ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"];
    const month = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];

    var sDate = StartDate;
    var eDate = EndDate;

    if (uniquePromotorList != null) {
        globalUniquePromotorList = uniquePromotorList;
    }

    sDate = sDate.split('-');
    sDate = sDate[0] + "-" + sDate[1] + "-" + sDate[2];
    sDate = new Date(sDate);
    sDate.setHours(0, 0, 0, 0);

    eDate = eDate.split('-');
    eDate = eDate[0] + "-" + eDate[1] + "-" + eDate[2];
    eDate = new Date(eDate);
    eDate.setHours(0, 0, 0, 0);

    var ArylocalRow = [];
    ArylocalRow[0] = cliente;
    ArylocalRow[1] = codigoRuta;
    ArylocalRow[2] = coordinador;
    ArylocalRow[3] = promotor;
    ArylocalRow[4] = det;
    ArylocalRow[5] = tienda;

    var loop = sDate;
    var vColumns = 5;
    //Loop to create each day heading, skip if all days have been generated
    while (loop <= eDate) {
        vColumns = vColumns + 1;
        var AryInfoItem = [];

        var vMHeading = weekday[loop.getDay()] + " " + loop.getDate() + "-" + month[parseInt(loop.getMonth())] + "-" + loop.getFullYear();

        AryInfoItem[0] = vMHeading;

        //Info data fetching
        var sDateFound = "False";

        for (var i = 0; i < info.length; i++) {

            var splittedDate = info[i].nombre.split('-');
            var infoDate = new Date(splittedDate[0], splittedDate[1] - 1, splittedDate[2]);
            infoDate.setHours(0, 0, 0, 0);
            if (loop.getTime() === infoDate.getTime()) {
                AryInfoItem[1] = info[i].ta;
                AryInfoItem[2] = info[i].cob;
                AryInfoItem[3] = info[i].fp;
                AryInfoItem[4] = info[i].dp;
                sDateFound = "True";
                break;
            }

        }

        if (sDateFound == "False") {
            AryInfoItem[1] = 0;
            AryInfoItem[2] = 0;
            AryInfoItem[3] = 0;
            AryInfoItem[4] = 0;
            AryInfoItem[5] = 0;
        }
        else {
            sDateFound = "False";
        }
        ArylocalRow[vColumns] = AryInfoItem;

        var newDate = loop.setDate(loop.getDate() + 1);
        loop = new Date(newDate);
    }

    //Add header title row to global var
    AryRows[CountRow] = ArylocalRow;
    fxnPrintGloabalData();
    //  return vTable = "<table>  <tr> main heading </tr> <tr> sub heading </tr> <tr> values </tr> </table>";
    return;

}

function generateInfoTemplate(info, sDay) {
    var vTotRow = "";
    var template = "";

    //for (var i = 0; i < Wetness.length; i++) {
    //    template = template + "<li>" + Wetness[i] + "</li>";
    //}
    var vTaTot = 0, vCobTot = 0, vFpTot = 0, vDpTot = 0;
    template = template + "<tr> <th> Day & Date </th> <th> TA </th> <th> COB </th> <th> FP </th> <th> DP </th> </th>";
    for (var i = 0; i < info.length; i++) {

        // debugger
        if (info[i].nombre.includes(sDay) == true) {

            var vta;
            try {
                vta = parseInt(info[i].ta); if (isNaN(vta)) { vta = 0; } vTaTot = vTaTot + vta;
            } catch { vta = "-"; }
            var vcob; try { vcob = parseInt(info[i].cob); if (isNaN(vcob)) { vcob = 0; } vCobTot = vCobTot + vcob; } catch { vcob = "-"; }
            var vfp; try { vfp = parseInt(info[i].fp); if (isNaN(vfp)) { vfp = 0; } vFpTot = vFpTot + vfp } catch { vfp = "-"; }
            var vdp; try { vdp = parseInt(info[i].dp); if (isNaN(vdp)) { vdp = 0; } vDpTot = vDpTot + vdp } catch { vdp = "-"; }

            template = template + "<tr> <td>" + info[i].nombre + "</td>";
            template = template + "<td>" + vta + "</td>";
            template = template + "<td>" + vcob + "</td>";
            template = template + "<td>" + vfp + "</td>";
            template = template + "<td>" + vdp + "%</td> </tr>";
        }



        // if (sCol.fecha.ToString().IndexOf("Lunes") > 0) {
        //template = template + "<tr> <td>" + subCol.Bound(sCol[i].ta.ToString()).Title("T.A.") + "</td>";
        //template = template + "<td>" + subCol.Bound(sCol[i].cob.ToString()).Title("COB") + "</td>";
        //template = template + "<td>" + subCol.Bound(sCol[i].fp.ToString()).Title("FP") + "</td>";
        //template = template + "<td>" + subCol.Bound(sCol[i].dp.ToString()).Title("DP") + "</td> </tr>";
        //  }
    }

    vTotRow = vTotRow + "<tr> <td> </td> <td> <strong> " + vTaTot + " </strong> </td> <td> <strong> " + vCobTot + " </strong> </td> <td> <strong> " + vFpTot + " </strong> </td> <td> <strong> " + vDpTot + "% </strong> </td> </tr>";

    return "<table>" + template + vTotRow + "</table>";

}

function getInfoVal(info, sDay, sAttribute) {
    var vTotRow = "";
    var template = "";


    var vTaTot = 0, vCobTot = 0, vFpTot = 0, vDpTot = 0;

    for (var i = 0; i < info.length; i++) {


        if (info[i].nombre.includes(sDay) == true) {

            if (sAttribute == "TA") {
                // debugger;
                var vta = 0; try {
                    vta = parseInt(info[i].ta);
                    if (isNaN(vta)) { vta = 0; }
                    vTaTot = vTaTot + vta;
                } catch { vta = "-"; }
                template = template + "<li>" + vta + "</li>";
                vTotRow = "<li> <strong>" + vTaTot + " </strong>  </li> ";

            }

            else if (sAttribute == "COB") {
                //  debugger;
                var vcob = 0;
                try {
                    vcob = parseInt(info[i].cob);
                    if (isNaN(vcob)) { vcob = 0; }
                    vCobTot = vCobTot + vcob;
                } catch { vcob = "-"; }
                template = template + "<li>" + vcob + "</li>";
                vTotRow = "<li><strong> " + vCobTot + " </strong>  </li> ";
            }

            else if (sAttribute == "FP") {
                //  debugger;
                var vfp = 0;
                try {
                    vfp = parseInt(info[i].fp);
                    if (isNaN(vfp)) { vfp = 0; }
                    vFpTot = vFpTot + vfp
                } catch { vfp = "-"; }
                template = template + "<li>" + vfp + "</li>";
                vTotRow = "<li><strong> " + vFpTot + " </strong>  </li> ";
            }
            else if (sAttribute == "DP") {
                //  debugger;
                var vdp = 0;
                try {
                    vdp = parseInt(info[i].dp);
                    if (isNaN(vdp)) { vdp = 0; }
                    vDpTot = vDpTot + vdp
                } catch { vdp = "-"; }
                template = template + "<li>" + vdp + "%</li>";
                vTotRow = "<li> <strong> " + vDpTot + " %</strong> </li> ";
            }

        }


    }

    //   vTotRow = vTotRow + "<tr> <td> </td> <td> <strong> " + vTaTot + " </strong> </td> <td> <strong> " + vCobTot + " </strong> </td> <td> <strong> " + vFpTot + " </strong> </td> <td> <strong> " + vDpTot + "% </strong> </td> </tr>";

    return "<ul>" + vTotRow + template + "</ul>";

}

//Expand all groupHeading Rows
function expandAll() {
    $('.collipsableContent').css('display', 'table-row-group');
    $('.groupHeading').addClass('active');
}

//Collapse all groupHeading Rows
function collapseAll() {
    $('.collipsableContent').css('display', 'none');
    $('.groupHeading').removeClass('active');
}

src = "https://unpkg.com/xlsx@0.15.1/dist/xlsx.full.min.js"


//Expand or collapse single groupHeading on click
$("body").on("click", "tr.groupHeading", function (e) {
    e.preventDefault();
    console.log("Si entro");
    console.log($(this).closest('tbody').next('tbody').css('display'));
    if ($(this).closest('tbody').next('tbody').css('display') == 'none') {
        $(this).closest('tbody').next('tbody').css('display', 'table-row-group');
        $(this).addClass('active');
    } else {
        $(this).closest('tbody').next('tbody').css('display', 'none');
        $(this).removeClass('active');
    }
    throw new Error('Codetica Rules');
});


function Template(cliente, codigoRuta, coordinador, promotor, det, tienda, info, StartDate, EndDate, uniquePromotorList) {
    CountRow = CountRow + 1;

    const weekday = ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"];
    const month = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];

    var sDate = StartDate;
    var eDate = EndDate;

    if (uniquePromotorList != null) {
        globalUniquePromotorList = uniquePromotorList;
    }

    sDate = sDate.split('-');
    sDate = sDate[0] + "-" + sDate[1] + "-" + sDate[2];
    sDate = new Date(sDate);
    sDate.setHours(0, 0, 0, 0);

    eDate = eDate.split('-');
    eDate = eDate[0] + "-" + eDate[1] + "-" + eDate[2];
    eDate = new Date(eDate);
    eDate.setHours(0, 0, 0, 0);

    var ArylocalRow = [];
    ArylocalRow[0] = cliente;
    ArylocalRow[1] = codigoRuta;
    ArylocalRow[2] = coordinador;
    ArylocalRow[3] = promotor;
    ArylocalRow[4] = det;
    ArylocalRow[5] = tienda;

    var loop = sDate;
    var vColumns = 5;

    //Loop to create each day heading, skip if all days have been generated
    while (loop <= eDate) {
        vColumns = vColumns + 1;
        var AryInfoItem = [];

        var vMHeading = weekday[loop.getDay()] + " " + loop.getDate() + "-" + month[parseInt(loop.getMonth())] + "-" + loop.getFullYear();

        AryInfoItem[0] = vMHeading;

        //Info data fetching
        var sDateFound = "False";
        for (var i = 0; i < info.length; i++) {

            var splittedDate = info[i].nombre.split('-');
            var infoDate = new Date(splittedDate[0], splittedDate[1] - 1, splittedDate[2]);
            infoDate.setHours(0, 0, 0, 0);
            if (loop.getTime() === infoDate.getTime()) {
                AryInfoItem[1] = info[i].ta;
                AryInfoItem[2] = info[i].cob;
                AryInfoItem[3] = info[i].fp;
                AryInfoItem[4] = info[i].dp;
                sDateFound = "True";
                break;
            }

        }

        if (sDateFound == "False") {
            AryInfoItem[1] = 0;
            AryInfoItem[2] = 0;
            AryInfoItem[3] = 0;
            AryInfoItem[4] = 0;
            AryInfoItem[5] = 0;
        }
        else {
            sDateFound = "False";
        }
        ArylocalRow[vColumns] = AryInfoItem;

        var newDate = loop.setDate(loop.getDate() + 1);
        loop = new Date(newDate);
    }

    //Add header title row to global var
    AryRows[CountRow] = ArylocalRow;
    fxnPrintGloabalData();
    return;

}

