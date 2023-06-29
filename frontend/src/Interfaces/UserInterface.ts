import axios from "axios";

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface User {
    id: number,
    login: string,
    role: string,
    roleId: number
}

export interface UserPermission {
    Role: string
}

const client = axios.create({
    baseURL: 'http://localhost:5555/api/v1/users',
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    execute(method: any, resource: any, data?: any, params?: any) {
        return client({
            method,
            url: resource,
            data,
            headers: { },
            params: params
        })
    },

    login (login: string, password: string) {
        console.log("Login: ", {login, password})
        console.log(this.execute('post', '/login', {login, password}))
        return this.execute('post', '/login', {login, password});
    },

    register (login: string, password: string, role: string, roleId: number) {
        return this.execute('post', '/register', {login, password, role, roleId});
    },

    getAll() {
        return this.execute('get', '/');
    },

    changeRole (id: string, Role: string) {
        console.log("changeRole:", {id, Role} );
        console.log(this.execute('patch', `/${id}`, {Role}));
        return this.execute('patch', `/${id}`, {Role});
    },
}