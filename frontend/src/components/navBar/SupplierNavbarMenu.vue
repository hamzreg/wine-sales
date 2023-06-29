<template>
  <div class="navbar-menu">
    <router-link style="text-decoration: none" to="/">
      <HomeButton>
        WineSales
      </HomeButton>
    </router-link>
    <router-link style="text-decoration: none" to="/catalog">
      <HomeButton>
        Каталог
      </HomeButton>
    </router-link>
    <router-link style="text-decoration: none" to="/supplierWines">
      <HomeButton>
        Мои Вина
      </HomeButton>
    </router-link>
    <router-link style="text-decoration: none" to="/supplierSales">
      <HomeButton>
        Продажи
      </HomeButton>
    </router-link>
    <router-link style="text-decoration: none" to="/aboutWines">
      <HomeButton>
        О Винах
      </HomeButton>
    </router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import HomeButton from '@/components/button/HomeButton.vue'

export default defineComponent({
  name: "SupplierNavbarMenu",
  components: {
    HomeButton
  }
})
</script>