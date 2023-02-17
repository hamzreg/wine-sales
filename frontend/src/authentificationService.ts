//import SquadInterface from "./Interfaces/SquadInterface";
import UserInterface from "./Interfaces/UserInterface";

interface User {
    id: number,
    login: string,
    Role: string
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

    async register(login: string, password: string) {
        const resUser = await UserInterface.register(login, password);
        console.log("RegisterAuth:", resUser.status);

        /* if (resUser.status == 200) {
            const resSquad = await SquadInterface.addSquad(0, login + "Squad", 0);
            console.log("AddSquadAuth:", resSquad.status);
            return true;
        } */

        return false;
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