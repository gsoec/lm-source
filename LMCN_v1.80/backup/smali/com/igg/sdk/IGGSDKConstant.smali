.class public Lcom/igg/sdk/IGGSDKConstant;
.super Ljava/lang/Object;
.source "IGGSDKConstant.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/IGGSDKConstant$orderType;,
        Lcom/igg/sdk/IGGSDKConstant$PushMessageBusinessType;,
        Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;,
        Lcom/igg/sdk/IGGSDKConstant$PayDNS;,
        Lcom/igg/sdk/IGGSDKConstant$PaymentType;,
        Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;,
        Lcom/igg/sdk/IGGSDKConstant$IGGFamily;,
        Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;,
        Lcom/igg/sdk/IGGSDKConstant$IGGIDC;,
        Lcom/igg/sdk/IGGSDKConstant$CDNType;,
        Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;,
        Lcom/igg/sdk/IGGSDKConstant$IGGMobileDeviceMessageState;,
        Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    }
.end annotation


# static fields
.field public static final ADM_REGISTERED_FAIL_INFO:Ljava/lang/String; = "From Amazon ADM Server: failed added device!"

.field public static final ADM_REGISTERED_SUCCESS_INFO:Ljava/lang/String; = "From Amazon ADM Server: successfully added device!"

.field public static final GCM_REGISTERED_FAIL_INFO:Ljava/lang/String; = "From GCM Server: failed added device!"

.field public static final GCM_REGISTERED_SUCCESS_INFO:Ljava/lang/String; = "From GCM Server: successfully added device!"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 9
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method
