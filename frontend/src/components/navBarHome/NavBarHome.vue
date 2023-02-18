<template>
  <div v-if="isInRole == 'supplier'" class="navbar-menu-container-home">
    <SupplierNavbarMenu />
    <LogoutNavbarMenu />
  </div>
  <div v-else-if="isInRole == 'customer'" class="navbar-menu-container-home">
    <CustomerNavbarMenu />
    <LogoutNavbarMenu />
  </div>
  <div v-else-if="isInRole == 'admin'" class="navbar-menu-container-home">
    <AdministratorNavbarMenu />
    <LogoutNavbarMenu />
  </div>
  <div v-else class="navbar-menu-container-home">
    <GuestNavbarMenu />
    <LoginNavbarMenu />
  </div>
</template>

<script lang="ts">
import { defineAsyncComponent, defineComponent } from 'vue'
import GuestNavbarMenu from '@/components/navBarHome/GuestNavbarMenuHome.vue'
import SupplierNavbarMenu from '@/components/navBarHome/SupplierNavbarMenuHome.vue'
import CustomerNavbarMenu from '@/components/navBarHome/CustomerNavbarMenuHome.vue'
import AdministratorNavbarMenu from '@/components/navBarHome/AdministratorNavbarMenuHome.vue'
import LoginNavbarMenu from '@/components/navBarHome/LoginNavbarMenuHome.vue'
import LogoutNavbarMenu from '@/components/navBarHome/LogoutNavbarMenuHome.vue'
import auth from '@/authentificationService'

export default defineComponent({
  name: "NavBarHome",
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
      if (auth.getCurrentUser()) { 
        return auth.getCurrentUser().role;
      }
      else {
        auth.logout()
        return "user"
      }
    }
  },
  methods: {

  }
})
</script>

<style scoped>
.navbar-menu-container-home {
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
  border-bottom: 2px solid var(--beige-color);
  background-color: var(--green-color);
  width: 100%;
}
.navbar-menu-home {
  display: flex;
  gap: 2%;
  padding-left: 4%;
  width: 100%;
  /* border: 2px solid var(--beige-color); */
}
.authorization-menu-home {
  display: flex;
  gap: 10%;
  /* border: 2px solid var(--beige-color); */
}
</style>
