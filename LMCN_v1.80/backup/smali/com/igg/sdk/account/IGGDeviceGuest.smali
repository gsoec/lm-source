.class public Lcom/igg/sdk/account/IGGDeviceGuest;
.super Lcom/igg/sdk/account/IGGGuest;
.source "IGGDeviceGuest.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "IGGDeviceGuest"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Lcom/igg/sdk/account/IGGGuest;-><init>()V

    return-void
.end method


# virtual methods
.method public getIdentifier()Ljava/lang/String;
    .locals 3
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 24
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getDeviceRegisterId()Ljava/lang/String;

    move-result-object v0

    .line 25
    .local v0, "deviceIdentifier":Ljava/lang/String;
    if-nez v0, :cond_0

    .line 26
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "IGGSDK.sharedInstance().getDeviceRegisterId() return NULL"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 29
    :cond_0
    return-object v0
.end method

.method public getReadableIdentifier()Ljava/lang/String;
    .locals 2

    .prologue
    .line 17
    :try_start_0
    invoke-virtual {p0}, Lcom/igg/sdk/account/IGGDeviceGuest;->getIdentifier()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v1

    .line 19
    :goto_0
    return-object v1

    .line 18
    :catch_0
    move-exception v0

    .line 19
    .local v0, "e":Ljava/lang/Exception;
    const-string v1, ""

    goto :goto_0
.end method

.method public setIdentifier(Ljava/lang/String;)V
    .locals 2
    .param p1, "identifier"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 33
    const-string v0, "IGGDeviceGuest"

    const-string v1, "setIdentifier is not supported in IGGDeviceGuest"

    invoke-static {v0, v1}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 34
    return-void
.end method
