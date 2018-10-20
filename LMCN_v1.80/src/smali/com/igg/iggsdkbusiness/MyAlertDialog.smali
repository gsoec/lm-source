.class public Lcom/igg/iggsdkbusiness/MyAlertDialog;
.super Landroid/app/AlertDialog;
.source "MyAlertDialog.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;,
        Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;
    }
.end annotation


# instance fields
.field focusListenable:Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 0
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 14
    invoke-direct {p0, p1}, Landroid/app/AlertDialog;-><init>(Landroid/content/Context;)V

    .line 15
    return-void
.end method


# virtual methods
.method public addOnWindowsFocusChangedListener(Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;)V
    .locals 0
    .param p1, "listener"    # Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;

    .prologue
    .line 18
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog;->focusListenable:Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;

    .line 19
    return-void
.end method

.method public onWindowFocusChanged(Z)V
    .locals 1
    .param p1, "hasFocus"    # Z

    .prologue
    .line 22
    if-eqz p1, :cond_0

    .line 23
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog;->focusListenable:Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;

    if-eqz v0, :cond_0

    .line 24
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog;->focusListenable:Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;

    invoke-interface {v0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;->onFocusChangedListener(Z)V

    .line 27
    :cond_0
    return-void
.end method
