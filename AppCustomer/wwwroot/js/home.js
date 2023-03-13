
//inicio - grafico Ativos Inativos

const ctx1 = document.getElementById('myChart');

const totalAtivos = document.querySelector('#totalAtivos').value;
const totalInativos = document.querySelector('#totalInativos').value;

//Chart.defaults.font.size = 12;
//Chart.defaults.color = '#e8eaf6';

new Chart(ctx1, {
    type: 'bar',
    data: {
        labels: ['Clientes Ativos', 'Clientes Inativos'],
        weigth: 300,
        datasets: [{
            label: 'Relação de Ativos e Inativos',
            data: [totalAtivos, totalInativos],
            borderWidth: 0,
            backgroundColor: ['#29b6f6', '#e57373']

        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

//fim - grafico Ativos Inativos


//inicio - grafico meta de clientes

const ctx2 = document.getElementById('myChart2');
const metaTotalClientes = document.querySelector('#metaTotalClientes').value;

new Chart(ctx2, {
    type: 'bar',
    data: {
        labels: ['Total Atual', 'Meta do Ano'],
        datasets: [{
            label: 'Quantidade de clientes',
            data: [metaTotalClientes, 200],
            borderWidth: 1,
            backgroundColor: ['#29b6f6', '#66bb6a'],
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

//fim - grafico meta de clientes


//inicio - grafico de faixa etaria

const ctx4 = document.getElementById('myChart4');

const totalJovens = document.querySelector('#totalJovens').value;
const totalAdultos = document.querySelector('#totalAdultos').value;
const totalVelhos = document.querySelector('#totalVelhos').value;

const data = {
    labels: [
        'Jovens',
        'Adultos',
        'Velhos'
    ],
    datasets: [{
        label: 'My First Dataset',
        data: [totalJovens, totalAdultos, totalVelhos],
        backgroundColor: [
            'rgb(255, 99, 132)',
            '#29b6f6',
            'rgb(255, 205, 86)'
        ],
        hoverOffset: 4,
        borderWidth: 0
    }]
};

new Chart(ctx4, {
    type: 'doughnut',
    data: data

});

//fim - grafico de faixa etaria
