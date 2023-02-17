<template>
  <div v-if="isInRole == 'supplier'" class="navbar-menu-container">
    <SupplierNavbarMenu />
    <LogoutNavbarMenu />
  </div>
  <div v-else-if="isInRole == 'customer'" class="navbar-menu-container">
    <CustomerNavbarMenu />
    <LogoutNavbarMenu />
  </div>
  <div v-else-if="isInRole == 'administrator'" class="navbar-menu-container">
    <AdministratorNavbarMenu />
    <LogoutNavbarMenu />
  </div>
  <div v-else class="navbar-menu-container">
    <GuestNavbarMenu />
    <LoginNavbarMenu />
  </div>
</template>

<script lang="ts">
import { defineAsyncComponent, defineComponent } from 'vue'
import GuestNavbarMenu from '@/components/navBar/GuestNavbarMenu.vue'
import SupplierNavbarMenu from '@/components/navBar/SupplierNavbarMenu.vue'
import CustomerNavbarMenu from '@/components/navBar/CustomerNavbarMenu.vue'
import AdministratorNavbarMenu from '@/components/navBar/AdministratorNavbarMenu.vue'
import LoginNavbarMenu from '@/components/navBar/LoginNavbarMenu.vue'
import LogoutNavbarMenu from '@/components/navBar/LogoutNavbarMenu.vue'
// import auth from '@/authentificationService'

export default defineComponent({
  name: "NavBar",
  components: {
    GuestNavbarMenu,
    SupplierNavbarMenu,
    CustomerNavbarMenu,
    AdministratorNavbarMenu,
    LoginNavbarMenu,
    LogoutNavbarMenu,
  },
  computed: {
    isInRole () {
      // if (auth.getCurrentUser()) { 
      //   return auth.getCurrentUser().permission;
      // }
      // else {
      //   auth.logout()
      //   return "guest"
      // }
      
      // return "supplier"
      // return "customer"
      // return "administrator"
      return "guest"
    }
  },
  methods: {

  }
})
</script>

<style scoped>
.navbar-menu-container {
  position: fixed;
  height: var(--navbar-height);
  left: 1;
  right: 0;
  padding-right: 2%;
  padding-top: 1%;
  padding-bottom: 1%;
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-bottom: 2px solid var(--green-color);
  width: 100%;
}
.navbar-menu {
  display: flex;
  gap: 2%;
  padding-left: 4%;
  width: 100%;
  /* border: 2px solid var(--beige-color); */
}
.authorization-menu {
  display: flex;
  gap: 10%;
  /* border: 2px solid var(--beige-color); */
}
</style>
