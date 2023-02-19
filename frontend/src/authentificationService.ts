import UserInterface from "./Interfaces/UserInterface";
import CustomerInterface from "./Interfaces/CustomerInterface";

interface User {
    id: number,
    login: string,
    Role: string,
}

interface Customer {
    name: string,
    surname: string,
    phone: string,
}

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
        console.log("AddCustomerAuth:", resCustomer.status);
        
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
            Role: "user"
        }
    
        localStorage.setItem('currentUser', JSON.stringify(user));
        console.log("currentUser: ", JSON.parse(String(localStorage.getItem("currentUser"))));
    }
}