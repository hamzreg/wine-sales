import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Sale {
    customerId: number
    supplierWineId: number
    sellingPrice: number
    purchasePrice: number
    profit: number
    wineNumber: number
}

const client = axios.create({
    baseURL: 'http://localhost:5555/api/v1/sales',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    name: "SaleInterface",

    execute(method: any, resource: any, data?: any, params?: any) {
        return client({
            method,
            url: resource,
            data,
            headers: { },
            params: params
        })
    },

    getAll() {
      return this.execute('get', '/');
    },

    getById(id: number) {
        return this.execute('get', `/${id}`);
    },

    post(sale: Sale) {
        return this.execute('post', '/', sale, null);
    },

    put(id: number, sale: Sale) {
        return this.execute('put', `/${id}`, sale, null);
    },

    delete(id: number) {
        return this.execute('delete', `/${id}`);
    }
}