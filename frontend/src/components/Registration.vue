<template>
  <Background>
    <body class="container">
      <body class="registration-container">
        <form class="form-column" @submit.prevent="onSubmit">
            <Text fontSize="var(--little-text)" fontColor>
              Регистрация
            </Text>
            <InputLine @login="setLogin" name="login" fontSize="var(--tiny-text)" placeholderText="Логин"/>
            <InputLine @password="setPassword" name="password" fontSize="var(--tiny-text)" placeholderText="Пароль"/>
            <InputLine @FirstName="setFirstName" name="FirstName" fontSize="var(--tiny-text)" placeholderText="Имя"/>
            <InputLine @SecondName="setSecondName" name="SecondName" fontSize="var(--tiny-text)" placeholderText="Фамилия"/>
            <InputLine @Phone="setPhone" name="Phone" fontSize="var(--tiny-text)" placeholderText="Номер телефона"/>
            <FormButton>
              Зарегистрироваться
            </FormButton>
            <div class="form-row">
              <Text fontSize="var(--tiny-text)">
                  Уже есть аккаунт?
              </Text>
              <Text fontSize="var(--tiny-text)">
                <router-link style="color: var(--wine-color)" to="/auth">Войти в аккаунт</router-link>
              </Text>
            </div>
        </form>
      </body>
    </body>
  </Background>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue'
  import InputLine from '@/components/InputLine.vue'
  import Text from "@/components/Text.vue"
  import FormButton from "@/components/button/FormButton.vue"
  import Background from "@/components/background/Background.vue"
  
  import auth from "@/authentificationService";
  import router from "@/router";
  
  export default defineComponent({
    name: "Authorization",
    components: {
      InputLine,
      FormButton,
      Text,
      Background,
    },
    data () {
      return {
        login: '',
        password: '',
        FirstName: '',
        SecondName: '',
        Phone: '',
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
      setFirstName(FirstName : string) {
        this.password = FirstName;
      },
      setSecondName(SecondName : string) {
        this.password = SecondName;
      },
      setPhone(Phone : string) {
        this.password = Phone;
      },
    }
  })
  </script>
  
  <style scoped>
  .container {
    display: flex;
    margin: 0;
    width: 100%;
    height: 100%;
    justify-content: center;
    align-items: center;
  }
  .registration-container {
    background: var(--green-color);
    box-shadow: 0px 0px 20px ;
    border-radius: 18px;
    padding-left: 2%;
    padding-right: 2%;
    padding-top: 1%;
    padding-bottom: 1%; 
    color: var(--beige-color);
    width: 30%;
    
  }
  .form-column {
    display: flex;
    flex-direction: column;
    text-align: center;
    gap: 10px;
  }
  
  .form-row {
    display: flex;
    flex-direction: column;
    gap: 10px;
    justify-content: center;
  }
  </style>