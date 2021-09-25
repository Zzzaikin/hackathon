<template>
  <v-overlay :value="loading" persistent>
    <v-row>
      <v-progress-circular
        indeterminate
        color="primary"
        size="46"
      ></v-progress-circular>
    </v-row>
  </v-overlay>
</template>

<script>
export default {
  data: () => ({}),
  props: ["loading"],
};
</script>
