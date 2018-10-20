.class public Lcom/igg/sdk/bean/IGGMobileDeviceInfo;
.super Ljava/lang/Object;
.source "IGGMobileDeviceInfo.java"


# instance fields
.field private country:Ljava/lang/String;

.field private language:Ljava/lang/String;

.field private mutingPeriod:[Ljava/lang/String;

.field private regId:Ljava/lang/String;

.field private timezone:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 3
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getCountry()Ljava/lang/String;
    .locals 1

    .prologue
    .line 19
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->country:Ljava/lang/String;

    return-object v0
.end method

.method public getLanguage()Ljava/lang/String;
    .locals 1

    .prologue
    .line 27
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->language:Ljava/lang/String;

    return-object v0
.end method

.method public getMutingPeriod()[Ljava/lang/String;
    .locals 1

    .prologue
    .line 35
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->mutingPeriod:[Ljava/lang/String;

    return-object v0
.end method

.method public declared-synchronized getRegId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 43
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->regId:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public getTimezone()Ljava/lang/String;
    .locals 1

    .prologue
    .line 11
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->timezone:Ljava/lang/String;

    return-object v0
.end method

.method public setCountry(Ljava/lang/String;)V
    .locals 0
    .param p1, "country"    # Ljava/lang/String;

    .prologue
    .line 23
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->country:Ljava/lang/String;

    .line 24
    return-void
.end method

.method public setLanguage(Ljava/lang/String;)V
    .locals 0
    .param p1, "language"    # Ljava/lang/String;

    .prologue
    .line 31
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->language:Ljava/lang/String;

    .line 32
    return-void
.end method

.method public setMutingPeriod([Ljava/lang/String;)V
    .locals 0
    .param p1, "mutingPeriod"    # [Ljava/lang/String;

    .prologue
    .line 39
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->mutingPeriod:[Ljava/lang/String;

    .line 40
    return-void
.end method

.method public declared-synchronized setRegId(Ljava/lang/String;)V
    .locals 1
    .param p1, "regId"    # Ljava/lang/String;

    .prologue
    .line 47
    monitor-enter p0

    :try_start_0
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->regId:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 48
    monitor-exit p0

    return-void

    .line 47
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public setTimezone(Ljava/lang/String;)V
    .locals 0
    .param p1, "timezone"    # Ljava/lang/String;

    .prologue
    .line 15
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGMobileDeviceInfo;->timezone:Ljava/lang/String;

    .line 16
    return-void
.end method
