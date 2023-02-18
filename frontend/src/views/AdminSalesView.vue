<template>
  <Background>
    <NavBarView>
      <SaleList/>
    </NavBarView>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Background from '@/components/background/Background.vue'
import NavBarView from './NavBarView.vue'
import SaleList from '@/components/sales/SaleList.vue'
    
export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    NavBarView,
    SaleList
  },
})
</script>


<style scoped>
</style>