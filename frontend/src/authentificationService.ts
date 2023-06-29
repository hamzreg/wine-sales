import { User } from "./Interfaces/UserInterface";
import UserInterface from "./Interfaces/UserInterface";
import { Customer } from "./Interfaces/CustomerInterface";
import CustomerInterface from "./Interfaces/CustomerInterface";

export interface Login {
    id: number,
    login: string,
    role: string,
    roleId: number
}

// interface Customer {
//     name: string,
//     surname: string,
//     phone: string,
// }

export default {
    async login(login: string, password: string) {
        const result = await UserInterface.login(login, password);
        console.log("LoginAuth:", result.status);

        if (result.status == 200) {
            console.log(result.data);
            localStorage.setItem('currentUser', JSON.stringify(result.data));
            console.log("currentUser: ", JSON.parse(String(localStorage.getItem("currentUser"))));
            return true;
        }

        return false;
    },

    async registerCustomer(login: string, password: string, role: string, name: string, surname: string, phone: string) {
        console.log("Register Customer")

        const customer: Customer = {
            name: name,
            surname: surname,
            phone: phone,
        }
        
        const resCustomer = await CustomerInterface.post(customer);
        console.log("AddCustomerAuth:", resCustomer.data["id"]);

        const resUser = await UserInterface.register(login, password, role, resCustomer.data["id"]);
        console.log("RegisterAuth:", resUser.status);

        return true;
    },
    
    getCurrentUser() {
        return JSON.parse(String(localStorage.getItem("currentUser")));
    },
    
    logout() {
        console.log("LogoutAuth");
        const user: User = {
            id: 0,
            login: "guest",
            role: "user",
            roleId: 0
        }
    
        localStorage.setItem('currentUser', JSON.stringify(user));
        console.log("currentUser: ", JSON.parse(String(localStorage.getItem("currentUser"))));
    }
}