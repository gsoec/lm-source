.class public Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;
.super Ljava/lang/Object;
.source "IGGSDKActivityStatistics.java"


# static fields
.field private static instance:Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;


# instance fields
.field private count:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 6
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static declared-synchronized sharedInstance()Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;
    .locals 2

    .prologue
    .line 12
    const-class v1, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->instance:Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    if-nez v0, :cond_0

    .line 13
    new-instance v0, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    invoke-direct {v0}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;-><init>()V

    sput-object v0, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->instance:Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    .line 16
    :cond_0
    sget-object v0, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->instance:Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-object v0

    .line 12
    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method


# virtual methods
.method public getCount()I
    .locals 1

    .prologue
    .line 20
    iget v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->count:I

    return v0
.end method

.method public setCount(I)V
    .locals 0
    .param p1, "count"    # I

    .prologue
    .line 24
    iput p1, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->count:I

    .line 25
    return-void
.end method
