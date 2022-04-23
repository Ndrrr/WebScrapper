let loadFlag = false;
let saveFlag = false;

let amazonCheck = document.getElementById("amazon-filter");
let trendyolCheck = document.getElementById("trendyol-filter");
let tapazCheck = document.getElementById("tapaz-filter");


function filterData() {
    let amazonCheck = document.getElementById("amazon-filter");
    let trendyolCheck = document.getElementById("trendyol-filter");
    let tapazCheck = document.getElementById("tapaz-filter");
    
    let table, tr, i;
    
    table = document.getElementById("data-table");
    tr = table.getElementsByTagName("tr");

    for (i = 1; i < tr.length; i++) {
        if ((tr[i].classList.contains("amazon") == true && amazonCheck.checked == true)
            || (tr[i].classList.contains("trendyol") == true && trendyolCheck.checked == true)
            || (tr[i].classList.contains("tapaz") ==true && tapazCheck.checked == true)) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
        
    }
}

document.getElementById("filter-btn").addEventListener("click", filterData);
let flag = 1;
function sortTable() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("data-table");
    switching = true;
    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[1];
            x = x.innerHTML.split("AZN")[0];
            y = rows[i + 1].getElementsByTagName("TD")[1];
            y = y.innerHTML.split("AZN")[0];
            x = parseInt(x);
            y = parseInt(y);
            if (flag == 1) {
                x = x * -1;
                y = y * -1;
            }
            if (x > y) {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
    flag = 1 - flag;
}


document.getElementById("sort-btn").addEventListener("click", sortTable);

