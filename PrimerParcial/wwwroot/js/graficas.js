document.addEventListener("DOMContentLoaded", function () {
    let promedios = [];
    let nombres = [];

    document.querySelectorAll("#alumnosTable tbody tr").forEach(row => {
        let nombre = row.cells[2].innerText;
        let promedio = parseFloat(row.cells[7].innerText);
        
        nombres.push(nombre);
        promedios.push(promedio);
    });

    let ctx = document.getElementById("grafica").getContext("2d");
    new Chart(ctx, {
        type: "bar",
        data: {
            labels: nombres,
            datasets: [{
                label: "Promedio",
                data: promedios,
                backgroundColor: "rgba(54, 162, 235, 0.6)",
                borderColor: "rgba(54, 162, 235, 1)",
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
});