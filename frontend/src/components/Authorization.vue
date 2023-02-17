<template>
  <body class="container">
    <body class="authorization-container">
      <form class="form-column" @submit.prevent="onSubmit">
          <Text fontSize="var(--large-text)" fontColor>
            Authorization
          </Text>
          <InputLine @login="setLogin" name="login" fontSize="var(--middle-text)" defaultText="Login*"/>
          <InputLine @password="setPassword" name="password" fontSize="var(--middle-text)" defaultText="Password*"/>
          <Button>
            Log In
          </Button>
          <div class="form-row">
            <Text fontSize="var(--little-text)">
                Don't have an account?
            </Text>
            <Text fontSize="var(--little-text)">
              <router-link style="color: var(--pink)" to="/registration">Sign Up now</router-link>
            </Text>
          </div>
      </form>
    </body>
  </body>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import InputLine from '@/components/InputLine.vue'
import Text from "@/components/Text.vue"
import Button from "@/components/button/Button.vue"

import auth from "@/authentificationService";
import router from "@/router";

export default defineComponent({
  name: "Authorization",
  components: {
    InputLine,
    Button,
    Text,
  },
  data () {
    return {
      login: '',
      password: '',
    }
  },
  methods: {
    async onSubmit() {
      console.log("Authorization:", this.login, this.password);

      if (this.login == '' || this.password == '') {
        this.$notify({
          title: "Error",
          text: "Login and Password are Required",
        });
        return;
      }

      const result = await auth.login(this.login, this.password);

      if (result) {
        console.log("You are logged in")
        router.push("/");
      }
      else {
        console.log("Incorrect Data")

        this.$notify({
          title: "Error",
          text: "Login Or Password is Incorrect",
        });
      }
    },
    setLogin(login : string) {
      this.login = login;
    },
    setPassword(password : string) {
      this.password = password;
    },
  }
})
</script>

<style scoped>
.authorization-container {
  background: blue;
  box-shadow: 0px 0px 20px ;
  border-radius: 20px 20px 20px 20px;
  padding-left: 2%;
  padding-right: 2%;
  padding-top: 1%;
  padding-bottom: 1%; 
  color: red;
  width: 35%;
}
.form-column {
  display: flex;
  flex-direction: column;
  text-align: center;
  gap: 10px;
}
.form-row {
  display: flex;
  flex-direction: row;
  gap: 10px;
  justify-content: center;
}
</style>