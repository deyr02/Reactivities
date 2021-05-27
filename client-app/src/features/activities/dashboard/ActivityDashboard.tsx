import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Grid, List } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import ActivityFilter from './ActivityFilter';
import ActivityList from './ActivityList';




export default observer( function ActivityDashboard(){
    const {activityStore} = useStore();
    const {loadingActivities, activityRegistry} = activityStore


    useEffect(()=>{
    if(activityRegistry.size <=1) loadingActivities();
    }, [activityRegistry.size, loadingActivities])
    
    if(activityStore.loadingInitial) return<LoadingComponent content="loading app"></LoadingComponent>

    return(
        <Grid>
            <Grid.Column width = '10'>
            <List>
                <ActivityList />
            </List>
            </Grid.Column>
            <Grid.Column width="6">
                <ActivityFilter/>
            </Grid.Column>
        </Grid>
    )
})