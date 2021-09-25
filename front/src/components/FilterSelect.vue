<template>
  <v-select
    outlined
    :label="label"
    :items="items"
    hide-details
    :multiple="multiple"
    :return-object="returnObject"
    :item-text="itemText"
    :value="value"
    @input="update($event)"
  >
    <template v-slot:selection="{ item, index }">
      <span v-if="index === 0">{{
        splitName(returnObject ? item[itemText] : item)
      }}</span>

      <span v-if="index === 1" class="grey--text text-caption">
        {{ value ? `+(${value.length - 1})` : "..." }}
      </span>
    </template>
  </v-select>
</template>

<script>
export default {
  data: () => ({}),
  props: ["items", "value", "multiple", "label", "returnObject", "itemText"],
  methods: {
    update(val) {
      this.$emit("input", val);
    },
    splitName(name) {
      console.log("name", name);
      console.log("ret", name.length > 14 ? name.substr(0, 13) + "..." : name);
      return name.length > 14 ? name.substr(0, 13) + "..." : name;
    },
  },
};
</script>
