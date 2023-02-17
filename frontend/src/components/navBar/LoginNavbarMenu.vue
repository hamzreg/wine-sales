<template>
  <div class="authorization-menu">
    <router-link style="text-decoration: none" to="/">
      <HomeButton >
        Авторизация
      </HomeButton>
    </router-link>
    <router-link style="text-decoration: none" to="/">
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
  name: "LoginNavbarMenu",
  components: {
    HomeButton,
  }
})
</script>