const fs = require('fs');
require('dotenv').config({ path: './.env' });


const pathFile = process.env.NODEJS_CSV_PATH;

fs.readdirSync(pathFile).forEach(file => {
    if (file.match("Relatorio-Janeiro-Maio.csv")) {
        let teste = fs.readFileSync(pathFile + '/' + file, 'utf-8');
        let objeto = csvToJson(teste);
        fs.writeFileSync(process.env.NODEJS_RESULT_PATH + '/'+'output.json', objeto);
    }
});

function csvToJson(file) {
    let arr = file.split('\n');
    let result = [];
    let headers = arr[0].split(';');
    for (let i = 1; i < arr.length; i++) {
        let data = arr[i].split(';');
        let obj = {};
        for (let j = 0; j < data.length; j++) {
            obj[headers[j].trim()] = data[j].trim();
        }
        result.push(obj);
    }
    return JSON.stringify(result);
}