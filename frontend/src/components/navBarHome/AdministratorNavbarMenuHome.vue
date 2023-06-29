<template>
  <div class="navbar-menu-home">
    <router-link style="text-decoration: none" to="/">
      <Button>
        WineSales
      </Button>
    </router-link>
    <router-link style="text-decoration: none" to="/catalog">
      <Button>
        Каталог
      </Button>
    </router-link>
    <router-link style="text-decoration: none" to="/sales">
      <Button>
        Продажи
      </Button>
    </router-link>
    <router-link style="text-decoration: none" to="/aboutWines">
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
  name: "AdministratorNavbarMenuHome",
  components: {
    Button
  }
})
</script>