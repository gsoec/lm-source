.class public Lcom/igg/sdk/backgroundcheck/IGGSDKBackgroundUtil;
.super Ljava/lang/Object;
.source "IGGSDKBackgroundUtil.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGSDKBackgroundUtil"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static isIGGSDKAppInForeground(Landroid/content/Context;)Z
    .locals 5
    .param p0, "context"    # Landroid/content/Context;

    .prologue
    const/4 v0, 0x1

    const/4 v1, 0x0

    .line 17
    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v3, 0x15

    if-ge v2, v3, :cond_2

    .line 18
    const-string v2, "IGGSDKBackgroundUtil"

    const-string v3, "DeviceUtil.isAppInForeground"

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 19
    invoke-static {p0}, Lcom/igg/util/DeviceUtil;->isAppInForeground(Landroid/content/Context;)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 29
    :cond_0
    :goto_0
    return v0

    :cond_1
    move v0, v1

    .line 22
    goto :goto_0

    .line 25
    :cond_2
    const-string v2, "IGGSDKBackgroundUtil"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "IGGSDKActivityStatistics getCount:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-static {}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->sharedInstance()Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->getCount()I

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 26
    invoke-static {}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->sharedInstance()Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/sdk/backgroundcheck/IGGSDKActivityStatistics;->getCount()I

    move-result v2

    if-gtz v2, :cond_0

    move v0, v1

    .line 29
    goto :goto_0
.end method
