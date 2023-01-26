<script lang="ts">
	import { PUBLIC_API_URL } from '$env/static/public';

	// TODO: Move interfaces to global.d.ts
	interface RecordsResponseObject {
		records: Array<Record>;
		pagination: {
			count: number;
			next: string;
			prev: number;
		};
		error: {
			code: string;
			message: string;
		};
	}
	interface Record {
		id: string;
		slug: string;
		name: string;
		type: string;
		value: string;
		mxPriority: string;
		priority: string;
		creator: string;
		created: number;
		updated: number;
		createdAt: number;
		updatedAt: number;
		ttl: number;
	}

	async function getRecords(): Promise<RecordsResponseObject> {
		// TODO: Add error handling
		const response = await fetch(`${PUBLIC_API_URL}/records?domain=hargaaya.com`);
		return response.json();
	}

	$: recordsPromise = getRecords();

	// TODO: You should be able to update record. Dropdown, Modal or new page?
</script>

{#await recordsPromise}
	<div class="loading">Loading...</div>
{:then records}
	<div class="container">
		<h1>Records</h1>
		{#each records.records as record}
			<div class="record">
				<h3><b>Name:</b> "{record.name}"</h3>
				<p><b>Value:</b> {record.value}</p>
			</div>
		{/each}
	</div>
{:catch error}
	<div class="error">Something went wrong :/</div>
	<p>{error}</p>
{/await}

<style>
	* {
		font-family: 'Space Mono';
	}

	.loading {
		color: rgb(0, 0, 124);
	}

	.container {
		background: rgb(214, 214, 214);
		display: flex;
		flex-direction: column;
		gap: 1em;
		width: 32em;
		padding: 3em;
		margin: 5em auto;
	}

	.container h1 {
		font-size: 3em;
	}

	.record {
		background: rgb(220, 220, 220);
		padding: 1em;
	}

	.error {
		color: #580022;
	}
</style>
