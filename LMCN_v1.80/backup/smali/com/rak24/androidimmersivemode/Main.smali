.class public Lcom/rak24/androidimmersivemode/Main;
.super Ljava/lang/Object;
.source "Main.java"


# annotations
.annotation build Landroid/annotation/TargetApi;
    value = 0x15
.end annotation


# static fields
.field static _INSTANCE:Lcom/rak24/androidimmersivemode/Main;

.field static br:Landroid/content/BroadcastReceiver;

.field public static gamePaused:Z

.field static lastHeightDiff:I

.field static unityApp:Landroid/app/Application;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 19
    const/4 v0, 0x0

    sput-object v0, Lcom/rak24/androidimmersivemode/Main;->_INSTANCE:Lcom/rak24/androidimmersivemode/Main;

    .line 22
    const/4 v0, 0x0

    sput v0, Lcom/rak24/androidimmersivemode/Main;->lastHeightDiff:I

    .line 24
    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 26
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 28
    sput-object p0, Lcom/rak24/androidimmersivemode/Main;->_INSTANCE:Lcom/rak24/androidimmersivemode/Main;

    .line 29
    return-void
.end method

.method public static DisableAppPin(Landroid/app/Activity;)V
    .locals 2
    .param p0, "unityActivity"    # Landroid/app/Activity;

    .prologue
    .line 133
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x15

    if-lt v0, v1, :cond_0

    .line 135
    invoke-virtual {p0}, Landroid/app/Activity;->stopLockTask()V

    .line 137
    :cond_0
    return-void
.end method

.method public static EnableAppPin(Landroid/app/Activity;)V
    .locals 2
    .param p0, "unityActivity"    # Landroid/app/Activity;

    .prologue
    .line 125
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x15

    if-lt v0, v1, :cond_0

    .line 127
    invoke-virtual {p0}, Landroid/app/Activity;->startLockTask()V

    .line 129
    :cond_0
    return-void
.end method

.method public static ImmersiveMode(Landroid/view/View;)V
    .locals 3
    .param p0, "v"    # Landroid/view/View;

    .prologue
    .line 94
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x13

    if-lt v1, v2, :cond_0

    .line 96
    const/16 v0, 0x1e06

    .line 102
    .local v0, "flags":I
    invoke-virtual {p0, v0}, Landroid/view/View;->setSystemUiVisibility(I)V

    .line 104
    .end local v0    # "flags":I
    :cond_0
    return-void
.end method

.method public static ImmersiveModeFromCache(Landroid/app/Activity;)V
    .locals 6
    .param p0, "activity"    # Landroid/app/Activity;

    .prologue
    .line 108
    sget v2, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v3, 0x13

    if-lt v2, v3, :cond_0

    .line 110
    move-object v0, p0

    .line 111
    .local v0, "act":Landroid/app/Activity;
    new-instance v1, Landroid/os/Handler;

    invoke-direct {v1}, Landroid/os/Handler;-><init>()V

    .line 112
    .local v1, "h":Landroid/os/Handler;
    new-instance v2, Lcom/rak24/androidimmersivemode/Main$2;

    invoke-direct {v2, v0}, Lcom/rak24/androidimmersivemode/Main$2;-><init>(Landroid/app/Activity;)V

    .line 119
    const-wide/16 v4, 0x2bc

    .line 112
    invoke-virtual {v1, v2, v4, v5}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 121
    .end local v0    # "act":Landroid/app/Activity;
    .end local v1    # "h":Landroid/os/Handler;
    :cond_0
    return-void
.end method

.method public static instance()Lcom/rak24/androidimmersivemode/Main;
    .locals 1

    .prologue
    .line 33
    sget-object v0, Lcom/rak24/androidimmersivemode/Main;->_INSTANCE:Lcom/rak24/androidimmersivemode/Main;

    if-nez v0, :cond_0

    .line 34
    new-instance v0, Lcom/rak24/androidimmersivemode/Main;

    invoke-direct {v0}, Lcom/rak24/androidimmersivemode/Main;-><init>()V

    .line 35
    :goto_0
    return-object v0

    :cond_0
    sget-object v0, Lcom/rak24/androidimmersivemode/Main;->_INSTANCE:Lcom/rak24/androidimmersivemode/Main;

    goto :goto_0
.end method


# virtual methods
.method public EnableImmersiveMode(Landroid/content/Context;)V
    .locals 3
    .param p1, "currentContext"    # Landroid/content/Context;

    .prologue
    .line 41
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0x13

    if-lt v1, v2, :cond_0

    move-object v0, p1

    .line 42
    check-cast v0, Landroid/app/Activity;

    .line 43
    .local v0, "activity":Landroid/app/Activity;
    invoke-virtual {v0}, Landroid/app/Activity;->getWindow()Landroid/view/Window;

    move-result-object v1

    invoke-virtual {v1}, Landroid/view/Window;->getDecorView()Landroid/view/View;

    move-result-object v1

    invoke-static {v1}, Lcom/rak24/androidimmersivemode/Main;->ImmersiveMode(Landroid/view/View;)V

    .line 44
    invoke-virtual {v0}, Landroid/app/Activity;->getWindow()Landroid/view/Window;

    move-result-object v1

    invoke-virtual {v1}, Landroid/view/Window;->getDecorView()Landroid/view/View;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/rak24/androidimmersivemode/Main;->SetUIChangeListener(Landroid/view/View;)V

    .line 45
    sget-object v1, Lcom/unity3d/player/UnityPlayer;->currentActivity:Landroid/app/Activity;

    invoke-virtual {v1}, Landroid/app/Activity;->getApplication()Landroid/app/Application;

    move-result-object v1

    sput-object v1, Lcom/rak24/androidimmersivemode/Main;->unityApp:Landroid/app/Application;

    .line 47
    sget-object v1, Lcom/rak24/androidimmersivemode/Main;->unityApp:Landroid/app/Application;

    new-instance v2, Lcom/rak24/androidimmersivemode/Main$1;

    invoke-direct {v2, p0}, Lcom/rak24/androidimmersivemode/Main$1;-><init>(Lcom/rak24/androidimmersivemode/Main;)V

    invoke-virtual {v1, v2}, Landroid/app/Application;->registerActivityLifecycleCallbacks(Landroid/app/Application$ActivityLifecycleCallbacks;)V

    .line 90
    .end local v0    # "activity":Landroid/app/Activity;
    :cond_0
    return-void
.end method

.method SetUIChangeListener(Landroid/view/View;)V
    .locals 2
    .param p1, "v"    # Landroid/view/View;

    .prologue
    .line 141
    move-object v0, p1

    .line 142
    .local v0, "unityView":Landroid/view/View;
    new-instance v1, Lcom/rak24/androidimmersivemode/Main$3;

    invoke-direct {v1, p0, v0}, Lcom/rak24/androidimmersivemode/Main$3;-><init>(Lcom/rak24/androidimmersivemode/Main;Landroid/view/View;)V

    invoke-virtual {p1, v1}, Landroid/view/View;->setOnSystemUiVisibilityChangeListener(Landroid/view/View$OnSystemUiVisibilityChangeListener;)V

    .line 153
    return-void
.end method
