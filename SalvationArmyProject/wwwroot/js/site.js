﻿//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.

//today = new Date();
//currentMonth = today.getMonth();
//currentYear = today.getFullYear();
//selectYear = document.getElementById("year");
//selectMonth = document.getElementById("month");

//months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

//monthAndYear = document.getElementById("monthAndYear");
//showCalendar(currentMonth, currentYear);

//function next() {
//    currentYear = (currentMonth === 11) ? currentYear + 1 : currentYear;
//    currentMonth = (currentMonth + 1) % 12;
//    showCalendar(currentMonth, currentYear);
//}

//function previous() {
//    currentYear = (currentMonth === 0) ? currentYear - 1 : currentYear;
//    currentMonth = (currentMonth === 0) ? 11 : currentMonth - 1;
//    showCalendar(currentMonth, currentYear);
//}

//function highlightCell() {
//    var table = document.getElementById("calendar-body");
//    var cells = table.getElementsByTagName("td");

//    for (var k = 0; k < cells.length; k++) {
//        var cell = cells[k];
//        cell.onclick = function () {
//            [].forEach.call(cells, function (el) {
//                el.style.backgroundColor = " ";
//            });
//            this.style.backgroundColor = "blue";
//        }
//    }
//}

//function jump() {
//    currentYear = parseInt(selectYear.value);
//    currentMonth - parseInt(selectMonth.value);
//    showCalendar(currentMonth, currentYear);
//}

//function showCalendar(month, year) {

//    let firstDay = (new Date(year, month)).getDay();

//    tbl = document.getElementById("calendar-body");

//    tbl.innerHTML = "";

//    monthAndYear.innerHTML = months[month] + " " + year;
//    selectYear.value = year;
//    selectMonth.value = month;

//    let date = 1;
//    for (let i = 0; i < 6; i++) {
//        let row = document.createElement("tr");

//        for (let j = 0; j < 7; j++) {
//            if (i === 0 && j < firstDay) {
//                cell = document.createElement("td");
//                cellText = document.createTextNode("");
//                cell.appendChild(cellText);
//                row.appendChild(cell);
//            }
//            else if (date > daysInMonth(month, year)) {
//                break;
//            }

//            else {
//                cell = document.createElement("td");
//                cellText = document.createTextNode(date);
//                if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
//                    cell.classList.add("bg-info");
//                }
//                cell.appendChild(cellText);
//                row.appendChild(cell);
//                date++;
//            }
//        }

//        tbl.appendChild(row);
//    }
//}

//function daysInMonth(iMonth, iYear) {
//    return 32 - new Date(iYear, iMonth, 32).getDate();
//}


