<template>
  <div class="navbar-menu-home">
    <router-link style="text-decoration: none" to="/">
      <Button>
        Каталог
      </Button>
    </router-link>
    <router-link style="text-decoration: none" to="/">
      <Button>
        Корзина
      </Button>
    </router-link>
    <router-link style="text-decoration: none" to="/">
      <Button>
        О Винах
      </Button>
    </router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Button from '@/components/button/Button.vue'

export default defineComponent({
  name: "CustomerNavbarMenuHome",
  components: {
    Button
  }
})
</script>