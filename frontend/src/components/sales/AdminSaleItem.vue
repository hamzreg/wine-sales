<template>
  <div class="sale-item">
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.kind }} {{ wine.color }} {{ wine.sugar }} {{ wine.volume }} л
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ supplier.name }}
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.purchasePrice }} ₽
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.sellingPrice }} ₽
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.wineNumber }} шт
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.date }}
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ sale.profit }} ₽
		</Text>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'

import SupplierWineInterface from '@/Interfaces/SupplierWineInterface'
import WineInterface from '@/Interfaces/WineInterface'
import SupplierInterface from '@/Interfaces/SupplierInterface'
    
export default defineComponent({
  name: "AdminSaleItem",
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
        supplierID: 0
      },
      supplier: {
        name: ''
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
    this.supplierWine = await (await SupplierWineInterface.getById(this.sale.id)).data;
    this.supplier = await (await SupplierInterface.getById(this.supplierWine.supplierID)).data;
    this.wine = await (await WineInterface.getById(this.supplierWine.wineID)).data;
  }
})
</script>
  
  
<style scoped>
.sale-item {
  display: grid;
  grid-template-columns: 2fr 2fr 2fr 2fr 2fr 2fr 2fr;
  column-gap: 50px;
  width: 100%;
	border-top: 1px solid var(--green-color);
  padding-top: 2%;
}
</style>