<template>
  <div class="authorization-menu-home">
    <router-link style="text-decoration: none" to="/auth">
      <HomeButton >
        Авторизация
      </HomeButton>
    </router-link>
    <router-link style="text-decoration: none" to="/registration">
      <HomeButton>
        Регистрация
      </HomeButton>
    </router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import HomeButton from '@/components/button/HomeButton.vue'

export default defineComponent({
  name: "LoginNavbarMenuHome",
  components: {
    HomeButton,
  }
})
</script>