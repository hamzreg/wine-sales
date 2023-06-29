import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Wine {
    kind: string
    color: string
    sugar: string
    volume: number
    alcohol: number
    number: number
}

const client = axios.create({
    baseURL: 'http://localhost:5555/api/v1/wines',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    name: "WineInterface",

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

    post(wine: Wine) {
        return this.execute('post', '/', wine, null);
    },

    patch(id: number, wine: Wine) {
        return this.execute('put', `/${id}`, wine, null);
    },

    delete(id: number) {
        return this.execute('delete', `/${id}`);
    }
}