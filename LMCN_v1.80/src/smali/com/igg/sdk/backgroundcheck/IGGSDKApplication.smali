.class public Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;
.super Landroid/app/Application;
.source "IGGSDKApplication.java"


# instance fields
.field private appCount:I


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 10
    invoke-direct {p0}, Landroid/app/Application;-><init>()V

    .line 11
    const/4 v0, 0x0

    iput v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    .prologue
    .line 10
    iget v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    return v0
.end method

.method static synthetic access$008(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)I
    .locals 2
    .param p0, "x0"    # Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    .prologue
    .line 10
    iget v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    add-int/lit8 v1, v0, 0x1

    iput v1, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    return v0
.end method

.method static synthetic access$010(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)I
    .locals 2
    .param p0, "x0"    # Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;

    .prologue
    .line 10
    iget v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    add-int/lit8 v1, v0, -0x1

    iput v1, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    return v0
.end method


# virtual methods
.method public getAppCount()I
    .locals 1

    .prologue
    .line 56
    iget v0, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    return v0
.end method

.method public onCreate()V
    .locals 2

    .prologue
    .line 15
    invoke-super {p0}, Landroid/app/Application;->onCreate()V

    .line 16
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x15

    if-lt v0, v1, :cond_0

    .line 17
    new-instance v0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;

    invoke-direct {v0, p0}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication$1;-><init>(Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;)V

    invoke-virtual {p0, v0}, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->registerActivityLifecycleCallbacks(Landroid/app/Application$ActivityLifecycleCallbacks;)V

    .line 53
    :cond_0
    return-void
.end method

.method public setAppCount(I)V
    .locals 0
    .param p1, "appCount"    # I

    .prologue
    .line 60
    iput p1, p0, Lcom/igg/sdk/backgroundcheck/IGGSDKApplication;->appCount:I

    .line 61
    return-void
.end method
