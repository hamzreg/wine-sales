import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface SupplierWine {
    supplierId: number
    wineId: number
    price: number
    percent: number
}

const client = axios.create({
    baseURL: 'http://localhost:5555/api/v1/supplierWine',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    name: "SupplierWineInterface",

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

    post(supplierWine: SupplierWine) {
        return this.execute('post', '/', supplierWine, null);
    },

    patch(id: number, supplierWine: SupplierWine) {
        return this.execute('put', `/${id}`, supplierWine, null);
    },

    delete(id: number) {
        return this.execute('delete', `/${id}`);
    },

    getSupplier(id: number) {
        return this.execute('get', `/${id}/supplier`);
    }
}