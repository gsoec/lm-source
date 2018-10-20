.class public Lcom/igexin/b/a/d/e;
.super Landroid/content/BroadcastReceiver;

# interfaces
.implements Ljava/util/Comparator;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/content/BroadcastReceiver;",
        "Ljava/util/Comparator",
        "<",
        "Lcom/igexin/b/a/d/d;",
        ">;"
    }
.end annotation


# static fields
.field public static final g:Ljava/lang/String;

.field public static final u:J


# instance fields
.field private a:Z

.field final h:Lcom/igexin/b/a/d/i;

.field final i:Ljava/util/HashMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/Long;",
            "Lcom/igexin/b/a/d/a/b;",
            ">;"
        }
    .end annotation
.end field

.field final j:Ljava/util/concurrent/ConcurrentLinkedQueue;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/concurrent/ConcurrentLinkedQueue",
            "<",
            "Lcom/igexin/b/a/d/a/e;",
            ">;"
        }
    .end annotation
.end field

.field final k:Lcom/igexin/b/a/d/c;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/igexin/b/a/d/c",
            "<",
            "Lcom/igexin/b/a/d/d;",
            ">;"
        }
    .end annotation
.end field

.field final l:Ljava/util/concurrent/locks/ReentrantLock;

.field m:Landroid/os/PowerManager;

.field n:Landroid/app/AlarmManager;

.field o:Landroid/content/Intent;

.field p:Landroid/app/PendingIntent;

.field q:Landroid/content/Intent;

.field r:Landroid/app/PendingIntent;

.field s:Ljava/lang/String;

.field volatile t:Z


# direct methods
.method static constructor <clinit>()V
    .locals 4

    const-class v0, Lcom/igexin/b/a/d/e;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/igexin/b/a/d/e;->g:Ljava/lang/String;

    sget-object v0, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    const-wide/16 v2, 0x2

    invoke-virtual {v0, v2, v3}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v0

    sput-wide v0, Lcom/igexin/b/a/d/e;->u:J

    return-void
.end method

.method protected constructor <init>()V
    .locals 2

    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    new-instance v0, Ljava/util/concurrent/locks/ReentrantLock;

    invoke-direct {v0}, Ljava/util/concurrent/locks/ReentrantLock;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->l:Ljava/util/concurrent/locks/ReentrantLock;

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/b/a/d/e;->a:Z

    new-instance v0, Ljava/util/HashMap;

    const/4 v1, 0x7

    invoke-direct {v0, v1}, Ljava/util/HashMap;-><init>(I)V

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->i:Ljava/util/HashMap;

    new-instance v0, Lcom/igexin/b/a/d/c;

    invoke-direct {v0, p0, p0}, Lcom/igexin/b/a/d/c;-><init>(Ljava/util/Comparator;Lcom/igexin/b/a/d/e;)V

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->k:Lcom/igexin/b/a/d/c;

    new-instance v0, Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-direct {v0}, Ljava/util/concurrent/ConcurrentLinkedQueue;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->j:Ljava/util/concurrent/ConcurrentLinkedQueue;

    new-instance v0, Lcom/igexin/b/a/d/i;

    invoke-direct {v0, p0}, Lcom/igexin/b/a/d/i;-><init>(Lcom/igexin/b/a/d/e;)V

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->h:Lcom/igexin/b/a/d/i;

    sput-object p0, Lcom/igexin/b/a/d/d;->E:Lcom/igexin/b/a/d/e;

    return-void
.end method


# virtual methods
.method public final a(Lcom/igexin/b/a/d/d;Lcom/igexin/b/a/d/d;)I
    .locals 8

    const/4 v2, 0x1

    const/4 v1, -0x1

    iget v0, p1, Lcom/igexin/b/a/d/d;->A:I

    iget v3, p2, Lcom/igexin/b/a/d/d;->A:I

    if-le v0, v3, :cond_1

    move v0, v1

    :goto_0
    iget-wide v4, p1, Lcom/igexin/b/a/d/d;->u:J

    iget-wide v6, p2, Lcom/igexin/b/a/d/d;->u:J

    cmp-long v3, v4, v6

    if-nez v3, :cond_5

    :goto_1
    if-nez v0, :cond_0

    invoke-virtual {p1}, Ljava/lang/Object;->hashCode()I

    move-result v0

    invoke-virtual {p2}, Ljava/lang/Object;->hashCode()I

    move-result v1

    sub-int/2addr v0, v1

    :cond_0
    return v0

    :cond_1
    iget v0, p1, Lcom/igexin/b/a/d/d;->A:I

    iget v3, p2, Lcom/igexin/b/a/d/d;->A:I

    if-ge v0, v3, :cond_2

    move v0, v2

    goto :goto_0

    :cond_2
    iget v0, p1, Lcom/igexin/b/a/d/d;->v:I

    iget v3, p2, Lcom/igexin/b/a/d/d;->v:I

    if-ge v0, v3, :cond_3

    move v0, v1

    goto :goto_0

    :cond_3
    iget v0, p1, Lcom/igexin/b/a/d/d;->v:I

    iget v3, p2, Lcom/igexin/b/a/d/d;->v:I

    if-le v0, v3, :cond_4

    move v0, v2

    goto :goto_0

    :cond_4
    const/4 v0, 0x0

    goto :goto_0

    :cond_5
    iget-wide v4, p1, Lcom/igexin/b/a/d/d;->u:J

    iget-wide v6, p2, Lcom/igexin/b/a/d/d;->u:J

    cmp-long v0, v4, v6

    if-gez v0, :cond_6

    move v0, v1

    goto :goto_1

    :cond_6
    move v0, v2

    goto :goto_1
.end method

.method public final a(J)V
    .locals 5
    .annotation build Landroid/annotation/TargetApi;
        value = 0x13
    .end annotation

    iget-boolean v0, p0, Lcom/igexin/b/a/d/e;->t:Z

    if-eqz v0, :cond_1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "setalarm|"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd HH:mm:ss"

    sget-object v3, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v1, v2, v3}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    new-instance v2, Ljava/util/Date;

    invoke-direct {v2, p1, p2}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v1, v2}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    const-wide/16 v0, 0x0

    cmp-long v0, p1, v0

    if-gez v0, :cond_0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    sget-wide v2, Lcom/igexin/b/a/d/e;->u:J

    add-long p1, v0, v2

    :cond_0
    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->p:Landroid/app/PendingIntent;

    if-eqz v0, :cond_1

    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x13

    if-ge v0, v1, :cond_2

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/igexin/b/a/d/e;->p:Landroid/app/PendingIntent;

    invoke-virtual {v0, v1, p1, p2, v2}, Landroid/app/AlarmManager;->set(IJLandroid/app/PendingIntent;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    :cond_1
    :goto_0
    return-void

    :cond_2
    :try_start_1
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/igexin/b/a/d/e;->p:Landroid/app/PendingIntent;

    invoke-virtual {v0, v1, p1, p2, v2}, Landroid/app/AlarmManager;->setExact(IJLandroid/app/PendingIntent;)V
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    :try_start_2
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/igexin/b/a/d/e;->p:Landroid/app/PendingIntent;

    invoke-virtual {v0, v1, p1, p2, v2}, Landroid/app/AlarmManager;->set(IJLandroid/app/PendingIntent;)V
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_1

    goto :goto_0

    :catch_1
    move-exception v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "TaskService"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v0}, Ljava/lang/Throwable;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto :goto_0
.end method

.method public final a(Landroid/content/Context;)V
    .locals 5

    const/high16 v4, 0x8000000

    const/4 v3, 0x1

    iget-boolean v0, p0, Lcom/igexin/b/a/d/e;->a:Z

    if-nez v0, :cond_0

    const-string v0, "power"

    invoke-virtual {p1, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/os/PowerManager;

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->m:Landroid/os/PowerManager;

    iput-boolean v3, p0, Lcom/igexin/b/a/d/e;->t:Z

    const-string v0, "alarm"

    invoke-virtual {p1, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/app/AlarmManager;

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    new-instance v0, Landroid/content/IntentFilter;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "AlarmTaskSchedule."

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, p0, v0}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    new-instance v0, Landroid/content/IntentFilter;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "AlarmTaskScheduleBak."

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, p0, v0}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    new-instance v0, Landroid/content/IntentFilter;

    const-string v1, "android.intent.action.SCREEN_OFF"

    invoke-direct {v0, v1}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, p0, v0}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    new-instance v0, Landroid/content/IntentFilter;

    const-string v1, "android.intent.action.SCREEN_ON"

    invoke-direct {v0, v1}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, p0, v0}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "AlarmNioTaskSchedule."

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->s:Ljava/lang/String;

    new-instance v0, Landroid/content/IntentFilter;

    iget-object v1, p0, Lcom/igexin/b/a/d/e;->s:Ljava/lang/String;

    invoke-direct {v0, v1}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    invoke-virtual {p1, p0, v0}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    new-instance v0, Landroid/content/Intent;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "AlarmTaskSchedule."

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->o:Landroid/content/Intent;

    invoke-virtual {p0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    iget-object v1, p0, Lcom/igexin/b/a/d/e;->o:Landroid/content/Intent;

    invoke-static {p1, v0, v1, v4}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->p:Landroid/app/PendingIntent;

    new-instance v0, Landroid/content/Intent;

    iget-object v1, p0, Lcom/igexin/b/a/d/e;->s:Ljava/lang/String;

    invoke-direct {v0, v1}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->q:Landroid/content/Intent;

    invoke-virtual {p0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    add-int/lit8 v0, v0, 0x2

    iget-object v1, p0, Lcom/igexin/b/a/d/e;->q:Landroid/content/Intent;

    invoke-static {p1, v0, v1, v4}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/b/a/d/e;->r:Landroid/app/PendingIntent;

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->h:Lcom/igexin/b/a/d/i;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/i;->start()V

    :try_start_0
    invoke-static {}, Ljava/lang/Thread;->yield()V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    iput-boolean v3, p0, Lcom/igexin/b/a/d/e;->a:Z

    :cond_0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method public final a(Lcom/igexin/b/a/d/a/b;)Z
    .locals 6

    const/4 v0, 0x0

    if-nez p1, :cond_0

    new-instance v0, Ljava/lang/NullPointerException;

    invoke-direct {v0}, Ljava/lang/NullPointerException;-><init>()V

    throw v0

    :cond_0
    iget-object v2, p0, Lcom/igexin/b/a/d/e;->l:Ljava/util/concurrent/locks/ReentrantLock;

    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->tryLock()Z

    move-result v1

    if-eqz v1, :cond_1

    :try_start_0
    iget-object v1, p0, Lcom/igexin/b/a/d/e;->i:Ljava/util/HashMap;

    invoke-virtual {v1}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v1

    invoke-interface {p1}, Lcom/igexin/b/a/d/a/b;->o()J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/Set;->contains(Ljava/lang/Object;)Z
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result v1

    if-eqz v1, :cond_2

    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    :cond_1
    :goto_0
    return v0

    :cond_2
    :try_start_1
    iget-object v1, p0, Lcom/igexin/b/a/d/e;->i:Ljava/util/HashMap;

    invoke-interface {p1}, Lcom/igexin/b/a/d/a/b;->o()J

    move-result-wide v4

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    invoke-virtual {v1, v3, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    const/4 v0, 0x1

    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    goto :goto_0

    :catch_0
    move-exception v1

    :try_start_2
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "TaskService|"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v1}, Ljava/lang/Throwable;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    goto :goto_0

    :catchall_0
    move-exception v0

    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    throw v0
.end method

.method final a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/a/b;)Z
    .locals 2

    invoke-interface {p1}, Lcom/igexin/b/a/d/a/e;->b()I

    move-result v0

    const/high16 v1, -0x80000000

    if-le v0, v1, :cond_2

    if-gez v0, :cond_2

    move-object v0, p1

    check-cast v0, Lcom/igexin/b/a/d/d;

    iget-boolean v1, v0, Lcom/igexin/b/a/d/d;->t:Z

    if-eqz v1, :cond_1

    invoke-interface {p2, v0, p0}, Lcom/igexin/b/a/d/a/b;->a(Lcom/igexin/b/a/d/d;Lcom/igexin/b/a/d/e;)Z

    move-result v1

    :goto_0
    if-eqz v1, :cond_0

    invoke-virtual {v0}, Lcom/igexin/b/a/d/d;->c()V

    :cond_0
    move v0, v1

    :goto_1
    return v0

    :cond_1
    invoke-interface {p2, p1, p0}, Lcom/igexin/b/a/d/a/b;->a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/e;)Z

    move-result v1

    goto :goto_0

    :cond_2
    if-ltz v0, :cond_3

    const v1, 0x7fffffff

    if-ge v0, v1, :cond_3

    invoke-interface {p2, p1, p0}, Lcom/igexin/b/a/d/a/b;->a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/e;)Z

    move-result v0

    goto :goto_1

    :cond_3
    const/4 v0, 0x0

    goto :goto_1
.end method

.method public final a(Lcom/igexin/b/a/d/d;Z)Z
    .locals 2

    const/4 v0, 0x0

    if-nez p1, :cond_0

    new-instance v0, Ljava/lang/NullPointerException;

    invoke-direct {v0}, Ljava/lang/NullPointerException;-><init>()V

    throw v0

    :cond_0
    iget-boolean v1, p1, Lcom/igexin/b/a/d/d;->p:Z

    if-nez v1, :cond_1

    iget-boolean v1, p1, Lcom/igexin/b/a/d/d;->k:Z

    if-eqz v1, :cond_2

    :cond_1
    :goto_0
    return v0

    :cond_2
    iget-object v1, p0, Lcom/igexin/b/a/d/e;->k:Lcom/igexin/b/a/d/c;

    if-eqz p2, :cond_3

    iget-object v0, v1, Lcom/igexin/b/a/d/c;->e:Ljava/util/concurrent/atomic/AtomicInteger;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicInteger;->incrementAndGet()I

    move-result v0

    :cond_3
    iput v0, p1, Lcom/igexin/b/a/d/d;->A:I

    invoke-virtual {v1, p1}, Lcom/igexin/b/a/d/c;->a(Lcom/igexin/b/a/d/d;)Z

    move-result v0

    goto :goto_0
.end method

.method public final a(Lcom/igexin/b/a/d/d;ZZ)Z
    .locals 3

    const/4 v0, 0x1

    const/4 v1, 0x0

    if-nez p1, :cond_0

    new-instance v0, Ljava/lang/NullPointerException;

    invoke-direct {v0}, Ljava/lang/NullPointerException;-><init>()V

    throw v0

    :cond_0
    iget-boolean v2, p1, Lcom/igexin/b/a/d/d;->m:Z

    if-eqz v2, :cond_2

    :cond_1
    :goto_0
    return v1

    :cond_2
    if-eqz p2, :cond_5

    if-nez p3, :cond_5

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->d()V

    :try_start_0
    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->a_()V

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->t()V

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->v()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    iget-boolean v1, p1, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v1, :cond_3

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->c()V

    :cond_3
    move v1, v0

    goto :goto_0

    :catch_0
    move-exception v0

    const/4 v2, 0x1

    :try_start_1
    iput-boolean v2, p1, Lcom/igexin/b/a/d/d;->t:Z

    iput-object v0, p1, Lcom/igexin/b/a/d/d;->B:Ljava/lang/Exception;

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->p()V

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->w()V

    invoke-virtual {p0, p1}, Lcom/igexin/b/a/d/e;->a(Ljava/lang/Object;)Z

    invoke-virtual {p0}, Lcom/igexin/b/a/d/e;->f()V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    iget-boolean v0, p1, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v0, :cond_1

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->c()V

    goto :goto_0

    :catchall_0
    move-exception v0

    iget-boolean v1, p1, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v1, :cond_4

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->c()V

    :cond_4
    throw v0

    :cond_5
    if-eqz p3, :cond_6

    if-eqz p2, :cond_6

    :goto_1
    invoke-virtual {p0, p1, v0}, Lcom/igexin/b/a/d/e;->a(Lcom/igexin/b/a/d/d;Z)Z

    move-result v1

    goto :goto_0

    :cond_6
    move v0, v1

    goto :goto_1
.end method

.method public final a(Ljava/lang/Class;)Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->k:Lcom/igexin/b/a/d/c;

    if-eqz v0, :cond_0

    invoke-virtual {v0, p1}, Lcom/igexin/b/a/d/c;->a(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public final a(Ljava/lang/Object;)Z
    .locals 5

    const/4 v2, 0x0

    if-nez p1, :cond_0

    move v1, v2

    :goto_0
    return v1

    :cond_0
    :try_start_0
    instance-of v1, p1, Lcom/igexin/push/d/c/p;

    if-eqz v1, :cond_1

    move-object v0, p1

    check-cast v0, Lcom/igexin/push/d/c/p;

    move-object v1, v0

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "TaskService|responseTask|"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "|"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {p1}, Ljava/lang/Object;->hashCode()I

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "|"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v1, v1, Lcom/igexin/push/d/c/p;->e:Ljava/lang/Object;

    check-cast v1, Ljava/lang/String;

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->a(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_1
    :goto_1
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "TaskService|responseQueue ++ task = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v3, "@"

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p1}, Ljava/lang/Object;->hashCode()I

    move-result v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    instance-of v1, p1, Lcom/igexin/b/a/d/a/e;

    if-nez v1, :cond_2

    new-instance v1, Ljava/lang/ClassCastException;

    const-string v2, "response Obj is not a TaskResult "

    invoke-direct {v1, v2}, Ljava/lang/ClassCastException;-><init>(Ljava/lang/String;)V

    throw v1

    :cond_2
    check-cast p1, Lcom/igexin/b/a/d/a/e;

    invoke-interface {p1}, Lcom/igexin/b/a/d/a/e;->l()Z

    move-result v1

    if-eqz v1, :cond_3

    move v1, v2

    goto/16 :goto_0

    :cond_3
    invoke-interface {p1, v2}, Lcom/igexin/b/a/d/a/e;->b(Z)V

    iget-object v1, p0, Lcom/igexin/b/a/d/e;->j:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v1, p1}, Ljava/util/concurrent/ConcurrentLinkedQueue;->offer(Ljava/lang/Object;)Z

    const/4 v1, 0x1

    goto/16 :goto_0

    :catch_0
    move-exception v1

    goto :goto_1
.end method

.method public final b(J)V
    .locals 5
    .annotation build Landroid/annotation/TargetApi;
        value = 0x13
    .end annotation

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "setnioalarm|"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    new-instance v1, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd HH:mm:ss"

    sget-object v3, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v1, v2, v3}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    new-instance v2, Ljava/util/Date;

    invoke-direct {v2, p1, p2}, Ljava/util/Date;-><init>(J)V

    invoke-virtual {v1, v2}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    const-wide/16 v0, 0x0

    cmp-long v0, p1, v0

    if-gez v0, :cond_0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    sget-wide v2, Lcom/igexin/b/a/d/e;->u:J

    add-long p1, v0, v2

    :cond_0
    :try_start_0
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x13

    if-ge v0, v1, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/igexin/b/a/d/e;->r:Landroid/app/PendingIntent;

    invoke-virtual {v0, v1, p1, p2, v2}, Landroid/app/AlarmManager;->set(IJLandroid/app/PendingIntent;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1

    :goto_0
    return-void

    :cond_1
    :try_start_1
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/igexin/b/a/d/e;->r:Landroid/app/PendingIntent;

    invoke-virtual {v0, v1, p1, p2, v2}, Landroid/app/AlarmManager;->setExact(IJLandroid/app/PendingIntent;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_0

    :catch_0
    move-exception v0

    :try_start_2
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    const/4 v1, 0x0

    iget-object v2, p0, Lcom/igexin/b/a/d/e;->r:Landroid/app/PendingIntent;

    invoke-virtual {v0, v1, p1, p2, v2}, Landroid/app/AlarmManager;->set(IJLandroid/app/PendingIntent;)V
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_1

    goto :goto_0

    :catch_1
    move-exception v0

    goto :goto_0
.end method

.method public synthetic compare(Ljava/lang/Object;Ljava/lang/Object;)I
    .locals 1

    check-cast p1, Lcom/igexin/b/a/d/d;

    check-cast p2, Lcom/igexin/b/a/d/d;

    invoke-virtual {p0, p1, p2}, Lcom/igexin/b/a/d/e;->a(Lcom/igexin/b/a/d/d;Lcom/igexin/b/a/d/d;)I

    move-result v0

    return v0
.end method

.method public final e()V
    .locals 2

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->r:Landroid/app/PendingIntent;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->n:Landroid/app/AlarmManager;

    iget-object v1, p0, Lcom/igexin/b/a/d/e;->r:Landroid/app/PendingIntent;

    invoke-virtual {v0, v1}, Landroid/app/AlarmManager;->cancel(Landroid/app/PendingIntent;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :cond_0
    :goto_0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method protected final f()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->h:Lcom/igexin/b/a/d/i;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->h:Lcom/igexin/b/a/d/i;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/i;->isInterrupted()Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->h:Lcom/igexin/b/a/d/i;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/i;->interrupt()V

    :cond_0
    return-void
.end method

.method final g()V
    .locals 9

    const/high16 v8, -0x80000000

    const-string v0, "TaskService|call notifyObserver ~~~~"

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    :goto_0
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->j:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v0}, Ljava/util/concurrent/ConcurrentLinkedQueue;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_6

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->j:Ljava/util/concurrent/ConcurrentLinkedQueue;

    invoke-virtual {v0}, Ljava/util/concurrent/ConcurrentLinkedQueue;->poll()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/b/a/d/a/e;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "TaskService|notifyObserver responseQueue -- task = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    const/4 v1, 0x1

    invoke-interface {v0, v1}, Lcom/igexin/b/a/d/a/e;->b(Z)V

    const/4 v2, 0x0

    iget-object v3, p0, Lcom/igexin/b/a/d/e;->l:Ljava/util/concurrent/locks/ReentrantLock;

    invoke-virtual {v3}, Ljava/util/concurrent/locks/ReentrantLock;->lock()V

    :try_start_0
    iget-object v1, p0, Lcom/igexin/b/a/d/e;->i:Ljava/util/HashMap;

    invoke-virtual {v1}, Ljava/util/HashMap;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_0

    invoke-interface {v0}, Lcom/igexin/b/a/d/a/e;->m()J

    move-result-wide v4

    const-wide/16 v6, 0x0

    cmp-long v1, v4, v6

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/igexin/b/a/d/e;->i:Ljava/util/HashMap;

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v4

    invoke-virtual {v1, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igexin/b/a/d/a/b;

    if-eqz v1, :cond_7

    invoke-interface {v1}, Lcom/igexin/b/a/d/a/b;->n()Z

    move-result v4

    if-eqz v4, :cond_7

    invoke-virtual {p0, v0, v1}, Lcom/igexin/b/a/d/e;->a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/a/b;)Z
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result v1

    :goto_1
    move v2, v1

    :cond_0
    :goto_2
    if-nez v2, :cond_1

    invoke-interface {v0}, Lcom/igexin/b/a/d/a/e;->b()I

    move-result v1

    if-le v1, v8, :cond_1

    if-gez v1, :cond_1

    check-cast v0, Lcom/igexin/b/a/d/d;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/d;->c()V

    :cond_1
    invoke-virtual {v3}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    goto :goto_0

    :cond_2
    :try_start_1
    iget-object v1, p0, Lcom/igexin/b/a/d/e;->i:Ljava/util/HashMap;

    invoke-virtual {v1}, Ljava/util/HashMap;->values()Ljava/util/Collection;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v4

    :cond_3
    invoke-interface {v4}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {v4}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igexin/b/a/d/a/b;

    invoke-interface {v1}, Lcom/igexin/b/a/d/a/b;->n()Z

    move-result v5

    if-eqz v5, :cond_3

    invoke-virtual {p0, v0, v1}, Lcom/igexin/b/a/d/e;->a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/a/b;)Z
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    move-result v2

    if-eqz v2, :cond_3

    goto :goto_2

    :catch_0
    move-exception v1

    :try_start_2
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v1}, Ljava/lang/Throwable;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    if-nez v2, :cond_4

    invoke-interface {v0}, Lcom/igexin/b/a/d/a/e;->b()I

    move-result v1

    if-le v1, v8, :cond_4

    if-gez v1, :cond_4

    check-cast v0, Lcom/igexin/b/a/d/d;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/d;->c()V

    :cond_4
    invoke-virtual {v3}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    goto/16 :goto_0

    :catchall_0
    move-exception v1

    if-nez v2, :cond_5

    invoke-interface {v0}, Lcom/igexin/b/a/d/a/e;->b()I

    move-result v2

    if-le v2, v8, :cond_5

    if-gez v2, :cond_5

    check-cast v0, Lcom/igexin/b/a/d/d;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/d;->c()V

    :cond_5
    invoke-virtual {v3}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    throw v1

    :cond_6
    return-void

    :cond_7
    move v1, v2

    goto :goto_1
.end method

.method public final onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 4

    const-string v0, "android.intent.action.SCREEN_OFF"

    invoke-virtual {p2}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/b/a/d/e;->t:Z

    const-string v0, "screenoff"

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->k:Lcom/igexin/b/a/d/c;

    iget-object v0, v0, Lcom/igexin/b/a/d/c;->h:Ljava/util/concurrent/atomic/AtomicLong;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicLong;->get()J

    move-result-wide v0

    const-wide/16 v2, 0x0

    cmp-long v0, v0, v2

    if-lez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/d/e;->k:Lcom/igexin/b/a/d/c;

    iget-object v0, v0, Lcom/igexin/b/a/d/c;->h:Ljava/util/concurrent/atomic/AtomicLong;

    invoke-virtual {v0}, Ljava/util/concurrent/atomic/AtomicLong;->get()J

    move-result-wide v0

    invoke-virtual {p0, v0, v1}, Lcom/igexin/b/a/d/e;->a(J)V

    :cond_0
    :goto_0
    return-void

    :cond_1
    const-string v0, "android.intent.action.SCREEN_ON"

    invoke-virtual {p2}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/b/a/d/e;->t:Z

    const-string v0, "screenon"

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    goto :goto_0

    :cond_2
    invoke-virtual {p2}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v0

    const-string v1, "AlarmTaskSchedule."

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_3

    invoke-virtual {p2}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v0

    const-string v1, "AlarmTaskScheduleBak."

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_4

    :cond_3
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "receivealarm|"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v1, p0, Lcom/igexin/b/a/d/e;->t:Z

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-virtual {p0}, Lcom/igexin/b/a/d/e;->f()V

    goto :goto_0

    :cond_4
    iget-object v0, p0, Lcom/igexin/b/a/d/e;->s:Ljava/lang/String;

    invoke-virtual {p2}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    const-string v0, "receive nioalarm"

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    :try_start_0
    const-string v0, "TaskService|alarm time out #######"

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/b/a/b/a/a/d;->a()Lcom/igexin/b/a/b/a/a/d;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/b/a/b/a/a/d;->d()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    goto :goto_0
.end method
