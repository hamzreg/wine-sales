<template>
  <div class="sale-item">
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.kind }} {{ wine.color }} {{ wine.sugar }} {{ wine.volume }} л
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ supplierWine.price }} ₽
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.wineNumber }} шт
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.date }}
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ Math.round(supplierWine.price * sale.wineNumber) }} ₽
		</Text>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'

import SupplierWineInterface from '@/Interfaces/SupplierWineInterface'
import WineInterface from '@/Interfaces/WineInterface'
    
export default defineComponent({
  name: "SupplierSaleItem",
  components: {
    Text
  },
  props: {
    sale: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      supplierWine: {
        wineID: 0,
        supplierID: 0,
        price: 0
      },
      wine: {
        kind: '',
        color: '',
        sugar: '',
        volume: 0
      }
    }
  },
  async mounted() {
    this.supplierWine = await (await SupplierWineInterface.getById(this.sale["supplierWineID"])).data;
    this.wine = await (await WineInterface.getById(this.supplierWine.wineID)).data;
  }
})
</script>
  
  
<style scoped>
.sale-item {
  display: grid;
  grid-template-columns: 2fr 2fr 2fr 2fr 2fr;
  column-gap: 50px;
  width: 100%;
	border-top: 1px solid var(--green-color);
  padding-top: 2%;
}
</style>