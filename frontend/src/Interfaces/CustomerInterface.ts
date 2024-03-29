import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Customer {
    name: string,
    surname: string,
    phone: string,
}

const client = axios.create({
    baseURL: 'http://localhost:5555/api/v1/customers',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    name: "CustomerInterface",

    execute(method: any, resource: any, data?: any) {
        return client({
            method,
            url: resource,
            data,
            headers: { },
        })
    },

    getAll() {
      return this.execute('get', '/');
    },

    getById(id: number) {
        return this.execute('get', `/${id}`);
    },

    post(customer: Customer) {
        return this.execute('post', '/', customer);
    },

    // addCustomer(Name: string, Surname: string, Phone: string) {
    //     return this.execute('post', '/', {Name, Surname, Phone});
    // },

    patch(id: number, customer: Customer) {
        return this.execute('put', `/${id}`, customer);
    },

    delete(id: number) {
        return this.execute('delete', `/${id}`);
    }
}