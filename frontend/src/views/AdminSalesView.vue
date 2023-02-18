<template>
  <Background>
    <AdminSaleTitle></AdminSaleTitle>
    <SaleList></SaleList>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Background from '@/components/background/Background.vue'
import AdminSaleTitle from '@/components/sales/AdminSaleTitle.vue'
import SaleList from '@/components/sales/SaleList.vue'
    
export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    AdminSaleTitle,
    SaleList
  },
})
</script>


<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 90%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 10px;
}
</style>