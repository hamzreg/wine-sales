<template>
  <div class="authorization-menu">
    <Button @click="logout">
      Выйти
    </Button>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Button from '@/components/button/Button.vue'
import auth from "@/authentificationService"

export default defineComponent({
  name: "LogoutNavbarMenu",
  components: {
    Button,
  },
  methods: {
    logout () {
      auth.logout();
      this.$router.push({ path: '/auth' })
    },
  }
})
</script>