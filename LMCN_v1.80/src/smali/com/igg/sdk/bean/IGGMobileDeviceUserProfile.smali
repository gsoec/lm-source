.class public Lcom/igg/sdk/bean/IGGMobileDeviceUserProfile;
.super Ljava/lang/Object;
.source "IGGMobileDeviceUserProfile.java"


# instance fields
.field private mutedMessageTypes:[Ljava/lang/String;

.field private nickname:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 3
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getMutedMessageTypes()[Ljava/lang/String;
    .locals 1

    .prologue
    .line 16
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGMobileDeviceUserProfile;->mutedMessageTypes:[Ljava/lang/String;

    return-object v0
.end method

.method public getNickname()Ljava/lang/String;
    .locals 1

    .prologue
    .line 8
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGMobileDeviceUserProfile;->nickname:Ljava/lang/String;

    return-object v0
.end method

.method public setMutedMessageTypes([Ljava/lang/String;)V
    .locals 0
    .param p1, "mutedMessageTypes"    # [Ljava/lang/String;

    .prologue
    .line 20
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGMobileDeviceUserProfile;->mutedMessageTypes:[Ljava/lang/String;

    .line 21
    return-void
.end method

.method public setNickname(Ljava/lang/String;)V
    .locals 0
    .param p1, "nickname"    # Ljava/lang/String;

    .prologue
    .line 12
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGMobileDeviceUserProfile;->nickname:Ljava/lang/String;

    .line 13
    return-void
.end method
