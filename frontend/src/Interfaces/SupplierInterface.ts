import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Supplier {
    id: number
    name: string
    country: string
    license: boolean
}

const client = axios.create({
    baseURL: 'http://localhost:5555/api/v1/suppliers',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    name: "SupplierInterface",

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

    post(supplier: Supplier) {
        return this.execute('post', '/', supplier, null);
    },

    patch(id: number, supplier: Supplier) {
        return this.execute('put', `/${id}`, supplier, null);
    },

    delete(id: number) {
        return this.execute('delete', `/${id}`);
    },

    getSales(id: number) {
      return this.execute('get', `/${id}/sales`);
    },

    getSupplierWines(id: number) {
      return this.execute('get', `/${id}/supplierWines`)
    }
}