<template>
  <div class="authorization-menu">
    <router-link style="text-decoration: none" to="/auth">
      <Button>
        Авторизация
      </Button>
    </router-link>
    <router-link style="text-decoration: none" to="/registration">
      <Button>
        Регистрация
      </Button>
    </router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Button from '@/components/button/Button.vue'

export default defineComponent({
  name: "LoginNavbarMenu",
  components: {
    Button,
  }
})
</script>